using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomLevelPicker : MonoBehaviour {
    public GameObject levelPickerRowPrefab;
    public AllLevelsModel levelsModel;
    public string levelFileName;
    public bool enableEditing;

    public void Start() {
        ResetList();
    }

    public void ResetList() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        if (levelFileName == "LevelData") {
            levelsModel = AllLevelsModel.Load(levelFileName);
        } else {
            levelsModel = AllLevelsModel.Load(levelFileName);
        }
        CreateButtons(levelsModel.levels);
    }

    void CreateButtons(Dictionary<string, LevelModel> levels) {
        foreach (KeyValuePair<string, LevelModel> entry in levels) {

            GameObject levelPickerRow = Instantiate(levelPickerRowPrefab);
            levelPickerRow.transform.SetParent(transform, false);

            GameObject levelButton = levelPickerRow.transform.GetChild(0).gameObject;

            levelButton.GetComponent<Button>().onClick.AddListener(() => GoToLevel(entry.Key));
            TextMeshProUGUI txt = levelButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            txt.text = entry.Value.levelName;

            bool showLevelCompleted = !enableEditing && PlayerPrefs.GetString(entry.Key) == "complete";
            if (showLevelCompleted) {
                levelButton.transform.GetChild(1).gameObject.SetActive(true);
            }

            if (enableEditing) {
                GameObject editButton = levelPickerRow.transform.GetChild(1).gameObject;
                editButton.SetActive(true);
                editButton.GetComponent<Button>().onClick.AddListener(() => GoToLevelEditor(entry.Key));

                GameObject deleteButton = levelPickerRow.transform.GetChild(2).gameObject;
                deleteButton.SetActive(true);
                deleteButton.GetComponent<Button>().onClick.AddListener(() => DeleteLevel(entry.Key));
            }
        }
    }

    void DeleteLevel(string ID) {
        levelsModel.DeleteLevel(ID);
        ResetList();
    }

    void SetGameMode() {
        if (levelFileName == "LevelData") {
            GameInfo.gameMode = GameInfo.GameMode.Standard;
        } else {
            GameInfo.gameMode = GameInfo.GameMode.Custom;
        }
    }

    void GoToLevelEditor(string level) {
        GameInfo.editLevel = level;
        SetGameMode();
        SceneManager.LoadScene("LevelEditor");
    }

    void GoToLevel(string level) {
        GameInfo.level = level;
        SetGameMode();
        SceneManager.LoadScene("WordBridges");
    }
}
