using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SignDIrection : MonoBehaviour
{
    public List<string> textDirection;
    [SerializeField] private GameObject textDirectionUI;
    private bool uiOpen = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (!uiOpen)
            {
                Invoke("uiIsopen", 0.3f);
                if (textDirection.Count == 4)
                {
                    textDirectionUI.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = textDirection[0];
                    textDirectionUI.transform.GetChild(3).GetChild(0).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = textDirection[1];
                    textDirectionUI.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = textDirection[2];
                    textDirectionUI.transform.GetChild(3).GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = textDirection[3];
                    textDirectionUI.transform.GetChild(3).gameObject.SetActive(true);
                }
                else if (textDirection.Count == 3)
                {
                    textDirectionUI.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = textDirection[0];
                    textDirectionUI.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = textDirection[1];
                    textDirectionUI.transform.GetChild(2).GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = textDirection[2];
                    textDirectionUI.transform.GetChild(2).gameObject.SetActive(true);
                }
                else if (textDirection.Count == 2)
                {
                    textDirectionUI.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = textDirection[0];
                    textDirectionUI.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = textDirection[1];
                    textDirectionUI.transform.GetChild(1).gameObject.SetActive(true);
                }
                else if (textDirection.Count == 1)
                {
                    textDirectionUI.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = textDirection[0];
                    textDirectionUI.transform.GetChild(0).gameObject.SetActive(true);
                }
                else { }
            }
            else
            {
                Invoke("uiIsnopen", 0.3f);
                foreach (Transform child in textDirectionUI.transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            if (VoiceController.instance.voiceOpen)
            {
                if (textDirection.Count == 4)
                {
                    textDirectionUI.transform.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = textDirection[0];
                    textDirectionUI.transform.GetChild(3).GetChild(0).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = textDirection[1];
                    textDirectionUI.transform.GetChild(3).GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = textDirection[2];
                    textDirectionUI.transform.GetChild(3).GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = textDirection[3];
                    textDirectionUI.transform.GetChild(3).gameObject.SetActive(true);
                }
                else if (textDirection.Count == 3)
                {
                    textDirectionUI.transform.GetChild(2).GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = textDirection[0];
                    textDirectionUI.transform.GetChild(2).GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = textDirection[1];
                    textDirectionUI.transform.GetChild(2).GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = textDirection[2];
                    textDirectionUI.transform.GetChild(2).gameObject.SetActive(true);
                }
                else if (textDirection.Count == 2)
                {
                    textDirectionUI.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = textDirection[0];
                    textDirectionUI.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = textDirection[1];
                    textDirectionUI.transform.GetChild(1).gameObject.SetActive(true);
                }
                else if (textDirection.Count == 1)
                {
                    textDirectionUI.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = textDirection[0];
                    textDirectionUI.transform.GetChild(0).gameObject.SetActive(true);
                }
                else { }
                VoiceController.instance.voiceOpen = false;
                Invoke("uiIsopen", 0.3f);
            }
            else if (VoiceController.instance.voiceClose)
            {
                foreach (Transform child in textDirectionUI.transform)
                {
                    child.gameObject.SetActive(false);
                }
                VoiceController.instance.voiceClose = false;
                Invoke("uiNotopen", 0.3f);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (Transform child in textDirectionUI.transform)
            {
                child.gameObject.SetActive(false);
            }
            Invoke("uiIsnopen", 0.3f);
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
