using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject continalBlock;
    public GameObject mainManu;
    public GameObject chooseCha;
    public GameObject Score;
    private GameProgress gameProgress;
    // Start is called before the first frame update
    private void Start()
    {
        gameProgress = SaveLoadManagerGameProgress.LoadGameData();
        if (gameProgress.state >= 1)
        {
            Destroy(continalBlock);
        }
    }

    public void newGame()
    {
        mainManu.SetActive(false);
        chooseCha.SetActive(true);
    }
    public void ScorePage()
    {
        mainManu.SetActive(false);
        chooseCha.SetActive(false);
        Score.SetActive(true);
    }
    public void loadGame()
    {
        if (gameProgress.diffiCult == 1)
        {
            if (gameProgress.state == 1)
            {
                SceneManager.LoadScene("CT1_easy");
            }
            else if (gameProgress.state == 2)
            {
                SceneManager.LoadScene("CT2_easy");
            }
            else if (gameProgress.state == 3)
            {
                SceneManager.LoadScene("CT3_easy");
            }
            else if (gameProgress.state == 4)
            {
                SceneManager.LoadScene("CT4_easy");
            }
            else if (gameProgress.state == 5)
            {
                SceneManager.LoadScene("CT5_easy");
            }
        }
        else if (gameProgress.diffiCult == 2)
        {
            if (gameProgress.state == 1)
            {
                SceneManager.LoadScene("CT1_normal");
            }
            else if (gameProgress.state == 2)
            {
                SceneManager.LoadScene("CT2_normal");
            }
            else if (gameProgress.state == 3)
            {
                SceneManager.LoadScene("CT3_normal");
            }
            else if (gameProgress.state == 4)
            {
                SceneManager.LoadScene("CT4_normal");
            }
            else if (gameProgress.state == 5)
            {
                SceneManager.LoadScene("CT5_normal");
            }
        }
        else if (gameProgress.diffiCult == 3)
        {
            if (gameProgress.state == 1)
            {
                SceneManager.LoadScene("CT1_hard");
            }
            else if (gameProgress.state == 2)
            {
                SceneManager.LoadScene("CT2_hard");
            }
            else if (gameProgress.state == 3)
            {
                SceneManager.LoadScene("CT3_hard");
            }
            else if (gameProgress.state == 4)
            {
                SceneManager.LoadScene("CT4_hard");
            }
            else if (gameProgress.state == 5)
            {
                SceneManager.LoadScene("CT5_hard");
            }
        }
    }
    public void backToMenu()
    {
        mainManu.SetActive(true);
        chooseCha.SetActive(false);
        Score.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
