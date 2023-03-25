using System;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ShowImportModal : MonoBehaviour {
    public GameObject modal;
    public Button openModal;
    public Button import;
    public Button cancel;
    public string levelFileName;
    public CustomLevelPicker customLevelPicker;
    public TMP_InputField importField;

    public void Start() {
        openModal.onClick.AddListener(() => {
            modal.SetActive(true);
        });

        import.onClick.AddListener(() => {
            Guid guid = Guid.NewGuid();

            LevelModel model = ParseImportString(importField.text);
            if (model == null) {
                return;
            }

            AllLevelsModel allLevelsModel = AllLevelsModel.Load(levelFileName);
            allLevelsModel.SetLevel(model.ID, model);
            allLevelsModel.Save();
            if (levelFileName == "CustomLevelData") {
                GameInfo.customLevels = AllLevelsModel.Load(levelFileName);
            } else {
                GameInfo.standardLevels = AllLevelsModel.LoadFromResources(levelFileName);
            }

            customLevelPicker.ResetList();
            modal.SetActive(false);
        });

        cancel.onClick.AddListener(() => {
            modal.SetActive(false);
        });
    }

    public LevelModel ParseImportString(string base64) {

        Guid guid = Guid.NewGuid();

        byte[] data = Convert.FromBase64String(base64);
        string decodedString = Encoding.UTF8.GetString(data);

        string[] split = decodedString.Split(",");
        if (split.Length != 26) {
            return null;
        }
        string[,] letters = new string[5, 5];

        for (int i = 0; i < split.Length - 1; i++) {
            int x = i / 5;
            int y = i % 5;
            letters[x, y] = split[i];
        }

        string levelName = split[^1];


        LevelModel model = new() {
            ID = guid.ToString(),
            levelName = levelName,
            letters = letters,
        };


        return model;
    }

}
