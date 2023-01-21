using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomLevelPicker : MonoBehaviour {
    public GameObject levelButtonPrefab;
    public GameObject editButtonPrefab;
    public AllLevelsModel levelsModel;
    public string levelFileName;

    public void Start() {
        levelsModel = AllLevelsModel.Load(levelFileName);
        CreateButtons(levelsModel.levels);
    }

    void CreateButtons(Dictionary<string, LevelModel> levels) {
        foreach (KeyValuePair<string, LevelModel> entry in levels) {
            GameObject levelButton = Instantiate(levelButtonPrefab);
            levelButton.GetComponent<Button>().onClick.AddListener(() => GoToLevel(entry.Key));
            TextMeshProUGUI txt = levelButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            txt.text = entry.Value.levelName;

            levelButton.transform.SetParent(transform, false);

            GameObject editButton = Instantiate(editButtonPrefab);
            editButton.GetComponent<Button>().onClick.AddListener(() => GoToLevelEditor(entry.Key));
            editButton.transform.SetParent(transform, false);
        }
    }

    void GoToLevelEditor(string level) {
        GameInfo.editLevel = level;
        SceneManager.LoadScene("LevelEditor");
    }

    void GoToLevel(string level) {
        GameInfo.level = level;

        if (levelFileName == "LevelData") {
            GameInfo.gameMode = GameInfo.GameMode.Standard;
        } else {
            GameInfo.gameMode = GameInfo.GameMode.Custom;
        }
        SceneManager.LoadScene("WordBridges");
    }
}
