using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class textChat : MonoBehaviour
{
    public List<string> textChats;
    private bool uiOpen = false;
    [SerializeField] private GameObject textUI;
    private TMP_Text tMP_Text;
    private void Start()
    {
        tMP_Text = textUI.transform.GetChild(0).GetComponent<TMP_Text>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (textChats != null && textChats.Count > 0)
            {
                string combinedText = string.Join("\n", textChats);
                tMP_Text.text = combinedText;
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
        else if (collision.gameObject.CompareTag("Player"))
        {
            if (VoiceController.instance.voiceOpen)
            {
                if (textChats != null && textChats.Count > 0)
                {
                    string combinedText = string.Join("\n", textChats);
                    tMP_Text.text = combinedText;
                }
                textUI.SetActive(true);
                VoiceController.instance.voiceOpen = false;
                Invoke("uiIsopen", 0.3f);
            }
            else if (VoiceController.instance.voiceClose)
            {
                textUI.SetActive(false);
                VoiceController.instance.voiceClose = false;
                Invoke("uiNotopen", 0.3f);
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
