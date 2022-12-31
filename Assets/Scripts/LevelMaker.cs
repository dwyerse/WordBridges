using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;

public class LevelMaker : MonoBehaviour
{

    public TMP_InputField levelNameInput;

    public void SaveLevel()
    {
        print(levelNameInput.text);

        LevelModel model = new LevelModel();
        model.LevelName = "test";
        string[,] letters = new string[5, 5];
        letters[1, 2] = "Z";
        letters[2, 2] = "O";
        letters[3, 2] = "O";
        letters[2, 1] = "D";
        letters[2, 3] = "T";
        model.Letters = letters;

        print(model);

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream("MyFile.lvl", FileMode.Create, FileAccess.Write, FileShare.None);
        formatter.Serialize(stream, model);
        stream.Close();

        IFormatter des = new BinaryFormatter();
        Stream str = new FileStream("MyFile.lvl", FileMode.Open, FileAccess.Read, FileShare.Read);
        LevelModel obj = (LevelModel)des.Deserialize(str);
        str.Close();

        print(obj.Letters[1, 2]);
        print(obj.LevelName);


    }
}
