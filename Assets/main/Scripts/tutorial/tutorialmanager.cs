using UnityEngine;
using UnityEngine.SceneManagement;

public class tutorialmanager : MonoBehaviour
{
    public static tutorialmanager instance;
    private GameProgress gameProgress;
    [SerializeField] private GameObject player;
    [SerializeField] private Sprite male;
    [SerializeField] private Sprite feMale;
    [SerializeField] private RuntimeAnimatorController maleAnimate;
    [SerializeField] private RuntimeAnimatorController feMaleAnimate;
    private void Start()
    {
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
    }
    public void goToCT1()
    {
        gameProgress.state = 1;
        SaveLoadManagerGameProgress.SaveGameData(gameProgress);
        if (gameProgress.diffiCult == 1)
        {
            SceneManager.LoadScene("CT1_easy");
        }
        else if (gameProgress.diffiCult == 2)
        {
            SceneManager.LoadScene("CT1_normal");
        }
        else if (gameProgress.diffiCult == 3)
        {
            SceneManager.LoadScene("CT1_hard");
        }
    }
    private void Awake()
    {
        instance = this;
    }
}
