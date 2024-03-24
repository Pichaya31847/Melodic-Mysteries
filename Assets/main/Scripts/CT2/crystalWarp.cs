using UnityEngine;

public class crystalWarp : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            GameManagerCT2.instance.WinState();
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            if (VoiceController.instance.get)
            {
                GameManagerCT2.instance.WinState();
                VoiceController.instance.get = false;
            }
        }
    }
}
