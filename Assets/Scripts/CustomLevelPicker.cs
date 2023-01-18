using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomLevelPicker : MonoBehaviour
{
    public GameObject levelButtonPrefab;
    public AllLevelsModel levelsModel;
    public string levelFileName;

    public void Start()
    {
        levelsModel = AllLevelsModel.Load(levelFileName);
        CreateButtons(levelsModel.levels);
    }

    void CreateButtons(Dictionary<string, LevelModel> levels)
    {
        foreach (KeyValuePair<string, LevelModel> entry in levels)
        {
            GameObject buttonGO = Instantiate(levelButtonPrefab);
            Button buttonBU = buttonGO.GetComponent<Button>();
            buttonBU.onClick.AddListener(() => GoToLevel(entry.Key));
            TextMeshProUGUI txt = buttonGO.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            txt.text = entry.Value.levelName;

            buttonGO.transform.SetParent(transform, false);
        }
    }

    void GoToLevel(string level)
    {
        GameInfo.customLevel = level;
        SceneManager.LoadScene("WordBridges");
    }
}
