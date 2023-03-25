using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelEditor : MonoBehaviour {
    public TMP_InputField levelNameInput;
    public Transform letterContainer;
    public HintPanel hintPanel;
    public TextMeshProUGUI message;
    public TextMeshProUGUI shareable;
    LevelModel model;
    public string levelFileName;

    public void Start() {

        levelFileName = GameInfo.gameMode == GameInfo.GameMode.Custom ? "CustomLevelData" : "LevelData";
        if (GameInfo.editLevel != null) {
            if (GameInfo.gameMode == GameInfo.GameMode.Custom) {
                model = GameInfo.customLevels.levels[GameInfo.editLevel];
            } else {
                model = GameInfo.standardLevels.levels[GameInfo.editLevel];
            }
            if (model.letters != null) {
                SetLetters(model.letters);
            }
            levelNameInput.text = model.levelName;
        } else {
            Guid guid = Guid.NewGuid();

            model = new() {
                levelName = levelNameInput.text,
                letters = GetLetters(),
                ID = guid.ToString()
            };
        }

        foreach (Transform child in letterContainer) {
            TMP_InputField inputField = child.GetComponent<TMP_InputField>();
            inputField.onValueChanged.AddListener(delegate { OnValueChanged(); });
        }
    }

    void OnValueChanged() {
        message.text = "";
        model.letters = GetLetters();
        PopulateHints(model.GetWords(model.letters));
    }

    public void UpdateShareableString() {
        string shareableString = model.GetShareableString();
        shareable.text = shareableString;
    }

    public string GetShareableString() {
        return model.GetShareableString();
    }

    public void SaveLevel() {
        model.levelName = levelNameInput.text;

        if (model.levelName == "") {
            message.text = "Give the board a name";
            return;
        }

        if (!model.IsSolvable()) {
            message.text = "Board is not solvable";
            return;
        }

        AllLevelsModel allLevelsModel = AllLevelsModel.Load(levelFileName);
        allLevelsModel.SetLevel(model.ID, model);
        allLevelsModel.Save();
        if (levelFileName == "CustomLevelData") {
            GameInfo.customLevels = AllLevelsModel.Load(levelFileName);
        } else {
            GameInfo.standardLevels = AllLevelsModel.Load(levelFileName);
        }
        message.text = "Saved - " + model.levelName;
    }

    void PopulateHints(List<string> words) {
        hintPanel.Clear();
        foreach (var word in words) {
            if (!GameInfo.wordSet.Contains(word.ToLower())) {
                hintPanel.Add(word, new Color(0.8f, 0.3f, 0.3f));
            } else {
                hintPanel.Add(word, new Color(0.3f, 0.7f, 0.3f));
            }
        }
    }

    private string[,] GetLetters() {
        string[,] letters = new string[5, 5];

        int letterIndex = 0;

        foreach (Transform child in letterContainer) {
            TMP_InputField inputField = child.GetComponent<TMP_InputField>();

            int x = letterIndex / 5;
            int y = letterIndex % 5;

            letters[x, y] = inputField.text.ToUpper();
            letterIndex++;
        }

        return letters;
    }

    void SetLetters(string[,] letters) {
        int letterIndex = 0;

        foreach (Transform child in letterContainer) {
            TMP_InputField inputField = child.GetComponent<TMP_InputField>();

            int x = letterIndex / 5;
            int y = letterIndex % 5;

            inputField.text = letters[x, y];
            letterIndex++;
        }
    }
}
