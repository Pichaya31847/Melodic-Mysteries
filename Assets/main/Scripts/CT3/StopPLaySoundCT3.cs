using UnityEngine;

public class StopPLaySoundCT3 : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManagerCT3.instance.PauseMusic();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManagerCT3.instance.PlayMusic();
        }
    }
}
