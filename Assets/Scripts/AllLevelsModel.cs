using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

public class AllLevelsModel
{
    public static string LEVEL_FILE_NAME = "LevelData";
    public Dictionary<string, LevelModel> levels;
    public string levelFileName;

    public AllLevelsModel(Dictionary<string, LevelModel> levels, string levelFileName)
    {
        this.levels = levels;
        this.levelFileName = levelFileName;
    }

    public void Save()
    {
        IFormatter formatter = new BinaryFormatter();

        string jsonString = JsonConvert.SerializeObject(levels);
        Stream stream = new FileStream(levelFileName, FileMode.Create, FileAccess.Write, FileShare.None);
        formatter.Serialize(stream, jsonString);
        stream.Close();
    }

    public void SetLevel(string ID, LevelModel levelModel)
    {
        levels[ID] = levelModel;
    }

    public static AllLevelsModel Load(string levelFileName)
    {
        Dictionary<string, LevelModel> levels = null;

        try
        {
            IFormatter formatter = new BinaryFormatter();
            Stream fileStream = new FileStream(levelFileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            if (fileStream.Length != 0)
            {
                string deserializedString = (string)formatter.Deserialize(fileStream);
                if (deserializedString != null)
                {
                    levels = JsonConvert.DeserializeObject<Dictionary<string, LevelModel>>(deserializedString);
                }
            }
            fileStream.Close();
        }
        catch (Exception)
        {
        }
        levels ??= new();
        AllLevelsModel allLevelsModel = new(levels, levelFileName);
        return allLevelsModel;
    }

}