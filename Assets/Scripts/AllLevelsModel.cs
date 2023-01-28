using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using UnityEngine;

public class AllLevelsModel {
    public Dictionary<string, LevelModel> levels;
    public string levelFileName;

    public AllLevelsModel(Dictionary<string, LevelModel> levels, string levelFileName) {
        this.levels = levels;
        this.levelFileName = levelFileName;
    }

    public void Save() {
        IFormatter formatter = new BinaryFormatter();

        string jsonString = JsonConvert.SerializeObject(levels);
        Stream stream = new FileStream(Application.persistentDataPath + levelFileName, FileMode.Create, FileAccess.Write, FileShare.None);
        formatter.Serialize(stream, jsonString);
        stream.Close();
    }

    public void SetLevel(string ID, LevelModel levelModel) {
        levels[ID] = levelModel;
    }

    public void DeleteLevel(string ID) {
        levels.Remove(ID);
        Save();
    }

    public static AllLevelsModel Load(string levelFileName) {
        Dictionary<string, LevelModel> levels = null;

        try {
            IFormatter formatter = new BinaryFormatter();
            Stream fileStream = new FileStream(Application.persistentDataPath + levelFileName, FileMode.Open, FileAccess.Read, FileShare.Read);

            if (fileStream.Length != 0) {
                string deserializedString = (string)formatter.Deserialize(fileStream);
                if (deserializedString != null) {
                    levels = JsonConvert.DeserializeObject<Dictionary<string, LevelModel>>(deserializedString);
                }
            }
            fileStream.Close();
        } catch (Exception) {
        }
        levels ??= new();
        AllLevelsModel allLevelsModel = new(levels, levelFileName);
        return allLevelsModel;
    }

    public static AllLevelsModel LoadFromResources(string levelFileName) {
        TextAsset asset = Resources.Load<TextAsset>(levelFileName);

        Dictionary<string, LevelModel> levels = JsonConvert.DeserializeObject<Dictionary<string, LevelModel>>(asset.text);
        levels ??= new();
        AllLevelsModel allLevelsModel = new(levels, levelFileName);
        return allLevelsModel;
    }

}