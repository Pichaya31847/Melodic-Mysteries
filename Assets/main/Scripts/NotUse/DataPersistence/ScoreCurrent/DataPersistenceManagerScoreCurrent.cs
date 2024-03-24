using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistenceManagerScoreCurrent : MonoBehaviour
{
    public static DataPersistenceManagerScoreCurrent instance { get; private set; }
    [SerializeField] private string fileName;
    private GameDataScoreCurrent gameDataScoreCurrent;
    private List<IDataPersistenceScoreCurrent> dataPersistenceScoreCurrentObject = new List<IDataPersistenceScoreCurrent>();
    private FileDataHandlerScoreCurrent dataHandlerScoreCurrent;

    private void Start()
    {
        //FindAllDataPersistenceScoreCurrentObject();
        dataHandlerScoreCurrent = new FileDataHandlerScoreCurrent(Application.persistentDataPath, fileName);
    }
    public void NewGame()
    {
        gameDataScoreCurrent = new GameDataScoreCurrent();
    }

    public void LoadGame()
    {

        Debug.Log("Preload gameDataScoreCurrent");
        dataHandlerScoreCurrent = new FileDataHandlerScoreCurrent(Application.persistentDataPath, fileName);
        gameDataScoreCurrent = dataHandlerScoreCurrent.Load();

        Debug.Log("Loaded gameDataScoreCurrent");
        /*if (gameDataScoreCurrent == null)
        {
            NewGame();
        }
        foreach (IDataPersistenceScoreCurrent dataPersistenceScoreCurrentOBJ in dataPersistenceScoreCurrentObject)
        {
            dataPersistenceScoreCurrentOBJ.LoadData(gameDataScoreCurrent);
        }*/
    }



    public void SaveGame(int difficulty, int stageTime, int stageLevel)
    {

        /*foreach (IDataPersistenceScoreCurrent dataPersistenceScoreCurrentOBJ in dataPersistenceScoreCurrentObject)
        {
            dataPersistenceScoreCurrentOBJ.SaveData(ref gameDataScoreCurrent);
        }*/
        gameDataScoreCurrent.diffiCult = difficulty;
        var temp = gameDataScoreCurrent.StageTime.FirstOrDefault(e => e.StageLevel == stageLevel);
        if (temp == null)
        {
            gameDataScoreCurrent.StageTime.Add(new GameDataScoreCurrent.Stage(stageTime, stageLevel));
        }
        else
        {
            temp.Time = stageTime;
        }

        dataHandlerScoreCurrent.Save(gameDataScoreCurrent);
    }

    private List<IDataPersistenceScoreCurrent> FindAllDataPersistenceScoreCurrentObject()
    {
        IEnumerable<IDataPersistenceScoreCurrent> dataPersistencesScoreCurrentObject = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistenceScoreCurrent>();
        return new List<IDataPersistenceScoreCurrent>(dataPersistencesScoreCurrentObject);
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found morethan one Data!");
        }
        instance = this;
    }
}
