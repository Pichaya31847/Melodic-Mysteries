using UnityEngine;

public class GoToCT1 : MonoBehaviour
{
    private bool mStarted = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E) && !mStarted)
        {
            tutorialmanager.instance.goToCT1();
            mStarted = true;
        }
        else if (collision.gameObject.CompareTag("Player") && VoiceController.instance.get && !mStarted)
        {
            tutorialmanager.instance.goToCT1();
            mStarted = true;
        }
    }
}
