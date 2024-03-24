using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerCT1 : MonoBehaviour
{
    public static GameManagerCT1 instance;
    private AudioSource audioSource;
    [SerializeField] private GameObject player;
    [SerializeField] private Sprite male;
    [SerializeField] private Sprite feMale;
    [SerializeField] private RuntimeAnimatorController maleAnimate;
    [SerializeField] private RuntimeAnimatorController feMaleAnimate;
    [SerializeField] private GameObject BorderKeydown;
    [SerializeField] private GameObject BorderSpeek;
    [SerializeField] private GameObject Hints;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private TMP_Text hintsText;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject loseUI;
    [SerializeField] private TMP_Text timeUse;
    private ScoreCurrrentData scoreCurrrentData;
    private GameProgress gameProgress;
    private int teleportCount = 0;
    private bool GameIsPause = false;
    private bool gameEnd = false;
    private List<string> hintMesage;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        hintMesage = new List<string>() { "ลองนับสิ่งของดูสิ", "ลองกด E ที่สิ่งของเล่นดูยัง", "ลองเดินสำรวจให้ทั่วดู", "อาจจะมีอะไรบางอย่างอยู่ในหิน", "ลองอ่านป้ายยัง", "มีบางอย่างซ่อนอยู่หลังกำแพง", "ลองเดินไปดูด้านล่าง" };
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

    // Update is called once per frame
    void Update()
    {
        if (!PlayerController.instance.keydown)
        {
            BorderKeydown.SetActive(false);
            BorderSpeek.SetActive(true);
        }
        else
        {
            BorderKeydown.SetActive(true);
            BorderSpeek.SetActive(false);
        }
        if (teleportCount == 8)
        {
            int Num = Random.Range(1, hintMesage.Count);
            hintsText.text = hintMesage[Num];
            Hints.SetActive(true);
            teleportCount = 0;
            Invoke("CloseHints", 3f);
        }
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            WinState();
        }
    }

    public void CloseHints()
    {
        Hints.SetActive(false);
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

    public void FailWalkCount()
    {
        teleportCount += 1;
    }

    public void WinState()
    {
        soundManager.PlaySound(0);
        gameEnd = true;
        Time.timeScale = 0f;
        audioSource.Stop();
        float minutes = Mathf.FloorToInt(Timer.instance.timePass / 60);
        float seconds = Mathf.FloorToInt(Timer.instance.timePass % 60);
        timeUse.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        winUI.SetActive(true);
        scoreCurrrentData.diffiCult = gameProgress.diffiCult;
        scoreCurrrentData.state1 = Timer.instance.timePass;
        SaveLoadManagerScoreCurrrent.SaveGameData(scoreCurrrentData);
        gameProgress.state = 2;
        SaveLoadManagerGameProgress.SaveGameData(gameProgress);
    }

    public void LoseState()
    {
        soundManager.PlaySound(1);
        Time.timeScale = 0f;
        audioSource.Stop();
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

    private void Awake()
    {
        instance = this;
    }
}
