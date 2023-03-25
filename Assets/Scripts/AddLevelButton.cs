using System;
using UnityEngine;
using UnityEngine.UI;

public class AddLevelButton : MonoBehaviour {

    Button button;
    public string levelFileName;
    public CustomLevelPicker customLevelPicker;

    public void Start() {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => AddLevel());
    }

    void AddLevel() {
        Guid guid = Guid.NewGuid();

        LevelModel model = new() {
            ID = guid.ToString(),
            levelName = "",
            letters = new string[5, 5],
        };

        AllLevelsModel allLevelsModel = AllLevelsModel.Load(levelFileName);
        allLevelsModel.SetLevel(model.ID, model);
        allLevelsModel.Save();
        if (levelFileName == "CustomLevelData") {
            GameInfo.customLevels = AllLevelsModel.Load(levelFileName);
        } else {
            GameInfo.standardLevels = AllLevelsModel.LoadFromResources(levelFileName);
        }

        customLevelPicker.ResetList();
    }

}
