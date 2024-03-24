using UnityEngine;

public class gameEndCT5 : MonoBehaviour
{
    private bool mStarted = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E) && !mStarted)
        {
            gameManagerCT5.instance.WinState();
            mStarted = true;
        }
        else if (collision.gameObject.CompareTag("Player") && VoiceController.instance.get && !mStarted)
        {
            gameManagerCT5.instance.WinState();
            mStarted = true;
        }
    }
}
