using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandlerScoreCurrent
{
    private string dataDiePath = "";
    private string dataFileName = "";

    public FileDataHandlerScoreCurrent(string dataDiePath, string dataFileName)
    {
        this.dataDiePath = dataDiePath;
        this.dataFileName = dataFileName;
    }

    public GameDataScoreCurrent Load()
    {
        Debug.Log("Pre Path combine");
        string fullPath = Path.Combine(dataDiePath, dataFileName);
        Debug.Log(fullPath.ToString());
        GameDataScoreCurrent loadedData = new GameDataScoreCurrent();
        Debug.Log("FullPath = "+fullPath.ToString());
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = File.ReadAllText(fullPath);
                loadedData = OpenFileParse(dataToLoad); // JsonUtility.FromJson<GameDataScoreCurrent>(dataToLoad);
                return loadedData;
            }
            catch (Exception e) { Debug.LogError("Error when try to Load Data From File:" + fullPath + "\n" + e); }
        }
        else{
            Debug.LogError("Full Path not found");
            return new GameDataScoreCurrent();
        }
        if(loadedData == new GameDataScoreCurrent()){
            Debug.Log("LoadedDataWas new element");
        }
        return loadedData;
    }

    public string SaveFileParse (GameDataScoreCurrent input){
        
        string result = "";
        result = input.diffiCult.ToString()+"\n";
        foreach(var element in input.StageTime ){
            result = result + element.StageLevel +","+element.Time+"\n";
        }
        return result;
    }

    public GameDataScoreCurrent OpenFileParse (string input){
        GameDataScoreCurrent result = new GameDataScoreCurrent();
        var line = input.Split('\n');
        result.diffiCult = int.Parse(line[0]);
        
        for (int i = 1; i <= line.Length-1; i++)
        {
            if(line[i].Trim() !=""){
                var temp = line[i].Split(',');
                result.StageTime.Add(new GameDataScoreCurrent.Stage(int.Parse(temp[1]),int.Parse(temp[0])));
            }

        }

        return result;
    }

    public void Save(GameDataScoreCurrent dataScoreCurrent)
    {
        string fullPath = Path.Combine(dataDiePath, dataFileName);
        Debug.Log("Full Path Save ="+fullPath.ToString());
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            Debug.Log("Directory ="+Path.GetDirectoryName(fullPath).ToString());
            string dataToStore = SaveFileParse(dataScoreCurrent); //JsonUtility.ToJson(dataScoreCurrent, true);
            Debug.Log("Json ="+dataToStore);
            if(File.Exists(fullPath))File.Delete(fullPath);
            File.WriteAllText(fullPath,dataToStore);

            /*using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }*/
        }
        catch (Exception e)
        {
            Debug.LogError("Error When try to save Data to file: " + fullPath + "\n" + e);
        }
    }
}
