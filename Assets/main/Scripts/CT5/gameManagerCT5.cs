using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerCT5 : MonoBehaviour
{
    public static gameManagerCT5 instance;
    private AudioSource audioSource;
    [SerializeField] private GameObject player;
    [SerializeField] private Sprite male;
    [SerializeField] private Sprite feMale;
    [SerializeField] private RuntimeAnimatorController maleAnimate;
    [SerializeField] private RuntimeAnimatorController feMaleAnimate;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject loseUI;
    [SerializeField] private TMP_Text timeUse;
    [SerializeField] private TMP_Text timeavg;
    [SerializeField] private TMP_Text liveLeft;
    private ScoreCurrrentData scoreCurrrentData;
    private List<ScoreCurrrentData> dataList;
    private GameProgress gameProgress;
    private bool GameIsPause = false;
    private bool gameEnd = false;
    public int live;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        liveLeft.text = "<sprite=20>" + live;
        dataList = SaveLoadScore.LoadData();
        gameProgress = SaveLoadManagerGameProgress.LoadGameData();
        if (gameProgress.gender == 1)
        {
            player.GetComponent<SpriteRenderer>().sprite = male;
            player.GetComponent<Animator>().runtimeAnimatorController = maleAnimate;
        }
        else
        {
            player.GetComponent<SpriteRenderer>().sprite = feMale;
            player.GetComponent<Animator>().runtimeAnimatorController = feMaleAnimate;
        }
        scoreCurrrentData = SaveLoadManagerScoreCurrrent.LoadGameData();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gameEnd)
            {
                if (GameIsPause)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
        if (Timer.instance.timeLeft <= 0 && !gameEnd)
        {
            LoseState();
        }
        if (live == 0 && !gameEnd)
        {
            LoseState();
        }
    }

    public void Resume()
    {
        soundManager.PlaySound(2);
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
    public void Pause()
    {
        soundManager.PlaySound(2);
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
        GameIsPause = true;
    }
    public void WinState()
    {
        soundManager.PlaySound(0);
        gameEnd = true;
        Time.timeScale = 0f;
        float minutes = Mathf.FloorToInt(Timer.instance.timePass / 60);
        float seconds = Mathf.FloorToInt(Timer.instance.timePass % 60);
        timeUse.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        float timeall = (scoreCurrrentData.state1 + scoreCurrrentData.state2 + scoreCurrrentData.state3 + scoreCurrrentData.state4 + Timer.instance.timePass) / 5;
        float minAvg = Mathf.FloorToInt(timeall / 60);
        float secAvg = Mathf.FloorToInt(timeall % 60);
        timeavg.text = "avg " + string.Format("{0:00}:{1:00}", minAvg, secAvg);
        winUI.SetActive(true);
        scoreCurrrentData.diffiCult = gameProgress.diffiCult;
        scoreCurrrentData.state5 = Timer.instance.timePass;
        dataList.Add(scoreCurrrentData);
        SaveLoadScore.SaveData(dataList);
        scoreCurrrentData = new ScoreCurrrentData
        {
            diffiCult = 0,
            gender = 0,
            state1 = 0,
            state2 = 0,
            state3 = 0,
            state4 = 0,
            state5 = 0
        };
        gameProgress = new GameProgress
        {
            diffiCult = 0,
            state = 0,
            gender = 0,
        };
        SaveLoadManagerGameProgress.SaveGameData(gameProgress);
        SaveLoadManagerScoreCurrrent.SaveGameData(scoreCurrrentData);
    }
    public void LoseState()
    {
        soundManager.PlaySound(1);
        Time.timeScale = 0f;
        gameEnd = true;
        loseUI.SetActive(true);
    }
    public void RestartGame()
    {
        soundManager.PlaySound(2);
        if (VoiceController.instance.keywordRecognizer != null && VoiceController.instance.keywordRecognizer.IsRunning)
        {
            VoiceController.instance.keywordRecognizer.Stop();
        }
        VoiceController.instance.keywordActions.Clear();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextState(string nextState)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nextState);
    }
    public void HomePage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }

    public void PauseMusic()
    {
        audioSource.Pause();
    }
    public void PlayMusic()
    {
        audioSource.Play();
    }
    public void dieHearth()
    {
        live -= 1;
        liveLeft.text = "<sprite=20>" + live;
    }
    private void Awake()
    {
        instance = this;
    }
}
