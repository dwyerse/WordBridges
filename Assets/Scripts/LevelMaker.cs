using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class LevelMaker : MonoBehaviour
{
    public static string LEVEL_FILE_NAME = "LevelData";
    public TMP_InputField levelNameInput;
    public Transform letterContainer;
    public HintPanel hintPanel;

    public void SaveLevel()
    {
        LevelModel model = new()
        {
            LevelName = levelNameInput.text,
            Letters = GetLetters()
        };

        IsSolvable(model.Letters);

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(LEVEL_FILE_NAME, FileMode.Create, FileAccess.Write, FileShare.None);
        formatter.Serialize(stream, model);
        stream.Close();

        Stream str = new FileStream(LEVEL_FILE_NAME, FileMode.Open, FileAccess.Read, FileShare.Read);
        LevelModel obj = (LevelModel)formatter.Deserialize(str);
        str.Close();
    }

    List<string> GetHorizontalWords(string[,] letters)
    {
        List<string> wordList = new();

        for (int i = 0; i < letters.GetLength(0); i++)
        {
            for (int j = 0; j < letters.GetLength(1); j++)
            {
                print("" + letters[i, j]);
            }
        }

        return wordList;
    }

    bool IsSolvable(string[,] letters)
    {
        GetHorizontalWords(letters);

        return true;
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
