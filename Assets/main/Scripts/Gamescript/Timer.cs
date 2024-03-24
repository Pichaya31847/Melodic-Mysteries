using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    public float timeLeft;
    public float timePass;
    public bool timerOn = false;
    [SerializeField] private TMP_Text timerTXT;
    public static GameProgress gameProgress;
    // Start is called before the first frame update
    void Start()
    {
        gameProgress = SaveLoadManagerGameProgress.LoadGameData();
        timerOn = true;
        if (gameProgress.diffiCult == 1)
        {
            timeLeft = 900;
            timerTXT.color = new Color(0, 255, 0, 255);
        }
        else if (gameProgress.diffiCult == 2)
        {
            timeLeft = 600;
            timerTXT.color = new Color(255, 255, 0, 255);
        }
        else if (gameProgress.diffiCult == 3)
        {
            timeLeft = 420;
            timerTXT.color = new Color(255, 0, 0, 255);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timePass += Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                Debug.Log("time is up!!!");
                timeLeft = 0;
                timerOn = false;
            }
        }
    }
    void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerTXT.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private void Awake()
    {
        instance = this;
    }
}
