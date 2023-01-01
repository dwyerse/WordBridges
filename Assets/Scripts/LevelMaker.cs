using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class LevelMaker : MonoBehaviour
{
    public static string LEVEL_FILE_NAME = "LevelData";
    public TMP_InputField levelNameInput;
    public Transform letterContainer;
    public HintPanel hintPanel;
    public TextMeshProUGUI message;
    LevelModel model;

    public void Start()
    {

        Guid guid = Guid.NewGuid();

        model = new()
        {
            levelName = levelNameInput.text,
            letters = GetLetters(),
            ID = guid.ToString()
        };

        foreach (Transform child in letterContainer)
        {
            TMP_InputField inputField = child.GetComponent<TMP_InputField>();
            inputField.onValueChanged.AddListener(delegate { OnValueChanged(); });
        }
    }

    void OnValueChanged()
    {
        message.gameObject.SetActive(false);
        model.letters = GetLetters();
        PopulateHints(model.GetWords());
    }

    public void SaveLevel()
    {
        model.levelName = levelNameInput.text;

        if (model.levelName == "")
        {
            message.text = "Give the board a name";
            message.gameObject.SetActive(true);
            return;
        }

        if (!model.IsSolvable())
        {
            message.text = "Board is not solvable";
            message.gameObject.SetActive(true);
            return;
        }
        IFormatter formatter = new BinaryFormatter();

        Stream fileStream = new FileStream(LEVEL_FILE_NAME, FileMode.Open, FileAccess.Read, FileShare.Read);

        AllLevelsModel allLevelsModel = new();

        if (fileStream.Length != 0)
        {
            string deserializedString = (string)formatter.Deserialize(fileStream);
            if (deserializedString != null)
            {
                allLevelsModel = JsonConvert.DeserializeObject<AllLevelsModel>(deserializedString);
            }
        }

        allLevelsModel.levels ??= new();
        allLevelsModel.levels[model.ID] = model;
        fileStream.Close();

        string jsonString = JsonConvert.SerializeObject(allLevelsModel);
        Stream stream = new FileStream(LEVEL_FILE_NAME, FileMode.Create, FileAccess.Write, FileShare.None);
        formatter.Serialize(stream, jsonString);
        stream.Close();

        message.text = "Saved - " + model.levelName;
        message.gameObject.SetActive(true);
    }

    void PopulateHints(List<string> words)
    {
        hintPanel.Clear();
        foreach (var word in words)
        {
            if (!GameInfo.wordSet.Contains(word.ToLower()))
            {
                hintPanel.Add(word, new Color(0.8f, 0.3f, 0.3f));
            }
            else
            {
                hintPanel.Add(word, new Color(0.3f, 0.7f, 0.3f));
            }
        }
    }

    private string[,] GetLetters()
    {
        string[,] letters = new string[5, 5];

        int letterIndex = 0;

        foreach (Transform child in letterContainer)
        {
            TMP_InputField inputField = child.GetComponent<TMP_InputField>();

            int x = letterIndex / 5;
            int y = letterIndex % 5;

            letters[x, y] = inputField.text.ToUpper();
            letterIndex++;
        }

        return letters;
    }

}
