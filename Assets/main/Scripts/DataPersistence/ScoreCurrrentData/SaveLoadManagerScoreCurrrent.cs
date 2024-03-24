using System.IO;
using UnityEngine;

public class SaveLoadManagerScoreCurrrent : MonoBehaviour
{
    private static string filePath = Application.persistentDataPath + "/ScoreCurrrent.json";

    public static void SaveGameData(ScoreCurrrentData gameData)
    {
        string jsonData = JsonUtility.ToJson(gameData);
        File.WriteAllText(filePath, jsonData);
    }

    public static ScoreCurrrentData LoadGameData()
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            ScoreCurrrentData gameData = JsonUtility.FromJson<ScoreCurrrentData>(jsonData);
            return gameData;
        }
        else
        {
            Debug.LogWarning("ไม่พบไฟล์ข้อมูล - กำลังสร้างไฟล์ใหม่...");

            // สร้างข้อมูลเริ่มต้น
            ScoreCurrrentData defaultGameData = new ScoreCurrrentData
            {
                diffiCult = 0,
                gender = 0,
                state1 = 0,
                state2 = 0,
                state3 = 0,
                state4 = 0,
                state5 = 0
            };

            // เซฟข้อมูล
            SaveGameData(defaultGameData);

            return defaultGameData;
        }
    }
}
