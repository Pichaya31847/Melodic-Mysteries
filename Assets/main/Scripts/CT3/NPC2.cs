using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC2 : MonoBehaviour
{


    [SerializeField] private GameObject itemUI;
    [SerializeField] private GameObject itemUI2;
    [SerializeField] private Sprite itemPic;
    [SerializeField] private Sprite itemPic2;
    public List<string> textChats;
    public List<string> textChats2;
    public int itemNum;
    private bool uiOpen = false;
    [SerializeField] private GameObject textUI;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (itemPic2.name == itemUI2.transform.GetChild(0).GetComponent<Image>().sprite.name)
            {
                gameObject.GetComponents<BoxCollider2D>().ToList().ForEach(x => x.enabled = false);
                gameObject.GetComponent<Animator>().SetTrigger("walk");
            }
            else if (itemPic.name == itemUI.transform.GetChild(0).GetComponent<Image>().sprite.name && int.Parse(itemUI.transform.GetChild(1).GetComponent<TMP_Text>().text) >= itemNum)
            {
                if (textChats2 != null && textChats.Count > 0)
                {
                    string combinedText = string.Join("\n", textChats2);
                    textUI.transform.GetChild(0).GetComponent<TMP_Text>().text = combinedText;
                }
                if (!uiOpen)
                {
                    textUI.SetActive(true);
                    Invoke("uiIsopen", 0.3f);
                }
                else if (uiOpen)
                {
                    textUI.SetActive(false);
                    Invoke("uiIsnopen", 0.3f);
                }
            }
            else
            {
                if (textChats != null && textChats2.Count > 0)
                {
                    string combinedText = string.Join("\n", textChats);
                    textUI.transform.GetChild(0).GetComponent<TMP_Text>().text = combinedText;
                }
                if (!uiOpen)
                {
                    textUI.SetActive(true);
                    Invoke("uiIsopen", 0.3f);
                }
                else if (uiOpen)
                {
                    textUI.SetActive(false);
                    Invoke("uiIsnopen", 0.3f);
                }
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            textUI.SetActive(false);
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
}
