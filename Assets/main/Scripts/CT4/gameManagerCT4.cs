using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerCT4 : MonoBehaviour
{
    public static gameManagerCT4 instance;
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
    private ScoreCurrrentData scoreCurrrentData;
    private GameProgress gameProgress;
    private bool GameIsPause = false;
    private bool gameEnd = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            WinState();
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
        winUI.SetActive(true);
        scoreCurrrentData.diffiCult = gameProgress.diffiCult;
        scoreCurrrentData.state4 = Timer.instance.timePass;
        SaveLoadManagerScoreCurrrent.SaveGameData(scoreCurrrentData);
        gameProgress.state = 5;
        SaveLoadManagerGameProgress.SaveGameData(gameProgress);
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

    private void Awake()
    {
        instance = this;
    }
}
