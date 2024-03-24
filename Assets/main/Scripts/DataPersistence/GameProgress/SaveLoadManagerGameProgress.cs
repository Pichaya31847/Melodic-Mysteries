using System.IO;
using UnityEngine;

public class SaveLoadManagerGameProgress : MonoBehaviour
{
    private static string filePath = Application.persistentDataPath + "/GameProgress.json";

    public static void SaveGameData(GameProgress gameData)
    {
        string jsonData = JsonUtility.ToJson(gameData);
        File.WriteAllText(filePath, jsonData);
    }

    public static GameProgress LoadGameData()
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            GameProgress gameData = JsonUtility.FromJson<GameProgress>(jsonData);
            return gameData;
        }
        else
        {
            GameProgress defaultGameData = new GameProgress
            {
                diffiCult = 2,
                state = 0,
                gender = 1,
            };
            SaveGameData(defaultGameData);

            return defaultGameData;
        }
    }

    public static void DeleteData()
    {
        File.Delete(filePath);
        Debug.Log("Deleted JSON file: " + filePath);
    }
}
