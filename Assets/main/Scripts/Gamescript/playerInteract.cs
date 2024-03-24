using UnityEngine;

public class playerInteract : MonoBehaviour
{
    private bool uiOpen = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InteractObject") && !PlayerController.instance.keydown)
        {
            if (collision.transform.GetChild(0).CompareTag("Outline"))
            {
                collision.transform.GetChild(0).gameObject.SetActive(true);
            }
            collision.transform.GetChild(1).gameObject.SetActive(true);
            Invoke("uiIsopen", 0.3f);
        }
        else if (collision.gameObject.CompareTag("InteractObject"))
        {
            if (collision.transform.GetChild(0).CompareTag("Outline"))
            {
                collision.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InteractObject") && Input.GetKey(KeyCode.E))
        {
            if (!uiOpen)
            {
                collision.transform.GetChild(1).gameObject.SetActive(true);
                Invoke("uiIsopen", 0.3f);
            }
            else if (uiOpen)
            {
                collision.transform.GetChild(1).gameObject.SetActive(false);
                Invoke("uiNotopen", 0.3f);
            }
        }
        else if (collision.gameObject.CompareTag("InteractObject"))
        {
            if (VoiceController.instance.voiceOpen)
            {
                collision.transform.GetChild(1).gameObject.SetActive(true);
                VoiceController.instance.voiceOpen = false;
                Invoke("uiIsopen", 0.3f);
            }
            else if (VoiceController.instance.voiceClose)
            {
                collision.transform.GetChild(1).gameObject.SetActive(false);
                VoiceController.instance.voiceClose = false;
                Invoke("uiNotopen", 0.3f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InteractObject"))
        {
            if (collision.transform.GetChild(0).CompareTag("Outline"))
            {
                collision.transform.GetChild(0).gameObject.SetActive(false);
            }
            collision.transform.GetChild(1).gameObject.SetActive(false);
            Invoke("uiNotopen", 0.3f);
        }
    }

    void uiIsopen()
    {
        uiOpen = true;
    }
    void uiNotopen()
    {
        uiOpen = false;
    }
}
