using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadScore : MonoBehaviour
{
    private static string filePath = Application.persistentDataPath + "/Score.json";

    public static void SaveData(List<ScoreCurrrentData> gameData)
    {
        string jsonData = JsonConvert.SerializeObject(gameData);
        File.WriteAllText(filePath, jsonData);
    }

    public static List<ScoreCurrrentData> LoadData()
    {
        List<ScoreCurrrentData> dataList = new List<ScoreCurrrentData>();
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            dataList = JsonConvert.DeserializeObject<List<ScoreCurrrentData>>(jsonData);
        }
        else
        {
            dataList = new List<ScoreCurrrentData>();
        }
        return dataList;
    }
}
