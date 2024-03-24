using UnityEngine;

public class openImage : MonoBehaviour
{
    [SerializeField] private GameObject pictureUI;
    private bool uiOpen = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {

            if (!uiOpen)
            {
                pictureUI.SetActive(true);
                Invoke("uiIsopen", 0.3f);
            }
            else if (uiOpen)
            {
                pictureUI.SetActive(false);
                Invoke("uiIsnopen", 0.3f);
            }
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            if (VoiceController.instance.voiceOpen)
            {
                pictureUI.SetActive(true);
                VoiceController.instance.voiceOpen = false;
                Invoke("uiIsopen", 0.3f);
            }
            else if (VoiceController.instance.voiceClose)
            {
                pictureUI.SetActive(false);
                VoiceController.instance.voiceClose = false;
                Invoke("uiNotopen", 0.3f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlaySoundWhenClick.instance != null)
            {
                PlaySoundWhenClick.instance.StopSound();
            }
            pictureUI.SetActive(false);
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
