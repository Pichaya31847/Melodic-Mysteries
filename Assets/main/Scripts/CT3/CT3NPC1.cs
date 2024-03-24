using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CT3NPC1 : MonoBehaviour
{
    [SerializeField] private GameObject itemUI;
    [SerializeField] private Sprite itemPic;
    public List<string> textChats;
    public List<string> textChats2;
    public int itemNum;
    private bool uiOpen = false;
    [SerializeField] private GameObject textUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (itemPic.name == itemUI.transform.GetChild(0).GetComponent<Image>().sprite.name && int.Parse(itemUI.transform.GetChild(1).GetComponent<TMP_Text>().text) >= itemNum)
            {
                if (textChats != null && textChats.Count > 0)
                {
                    string combinedText = string.Join("\n", textChats);
                    textUI.transform.GetChild(0).GetComponent<TMP_Text>().text = combinedText;
                }
            }
            else
            {
                if (textChats2 != null && textChats2.Count > 0)
                {
                    string combinedText = string.Join("\n", textChats2);
                    textUI.transform.GetChild(0).GetComponent<TMP_Text>().text = combinedText;
                }
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
