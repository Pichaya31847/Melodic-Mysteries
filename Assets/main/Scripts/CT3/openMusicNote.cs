using UnityEngine;
using UnityEngine.UI;

public class openMusicNote : MonoBehaviour
{
    [SerializeField] private GameObject m_gameObject;
    public Sprite[] noteIMG;
    private int i = 0;
    private bool uiOpen = false;
    private GameObject gameObject1;
    private GameObject gameObject2;
    private Image image;

    private void Start()
    {
        gameObject1 = m_gameObject.transform.GetChild(1).GetChild(0).gameObject;
        gameObject2 = m_gameObject.transform.GetChild(1).GetChild(1).gameObject;
        image = m_gameObject.transform.GetChild(1).GetChild(2).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (i < noteIMG.Length - 1)
        {
            gameObject1.SetActive(true);
        }
        else
        {
            gameObject1.SetActive(false);
        }
        if (i != 0)
        {
            gameObject2.SetActive(true);
        }
        else
        {
            gameObject2.SetActive(false);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            m_gameObject.transform.GetChild(1).GetChild(2).GetComponent<Image>().sprite = noteIMG[i];
            if (!uiOpen)
            {
                m_gameObject.SetActive(true);
                Invoke("uiIsopen", 0.3f);
            }
            else if (uiOpen)
            {
                m_gameObject.SetActive(false);
                Invoke("uiIsnopen", 0.3f);
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            if (VoiceController.instance.get)
            {
                m_gameObject.transform.GetChild(1).GetChild(2).GetComponent<Image>().sprite = noteIMG[i];
                if (!uiOpen)
                {
                    m_gameObject.SetActive(true);
                    Invoke("uiIsopen", 0.3f);
                }
                else if (uiOpen)
                {
                    m_gameObject.SetActive(false);
                    Invoke("uiIsnopen", 0.3f);
                }
                VoiceController.instance.get = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            m_gameObject.SetActive(false);
            PlaySoundWhenClick.instance.StopSound();
            uiOpen = false;
        }
    }
    void uiIsopen()
    {
        uiOpen = true;
    }
    void uiIsnopen()
    {
        uiOpen = false;
    }
    public void nextPage()
    {
        i += 1;
        image.sprite = noteIMG[i];
    }
    public void backPage()
    {
        i -= 1;
        image.sprite = noteIMG[i];
    }
}
