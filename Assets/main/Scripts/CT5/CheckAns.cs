using System.Collections;
using UnityEngine;

public class CheckAns : MonoBehaviour
{
    [SerializeField] Transform teleportDestinationTrue;
    [SerializeField] Transform teleportDestinationFalse;
    [SerializeField] Animator transition;
    public bool ans;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (ans)
            {
                StartCoroutine(TeleportWithFadeTrue(collision.transform));
            }
            else
            {
                StartCoroutine(TeleportWithFadeFalse(collision.transform));
            }
        }
    }
    IEnumerator TeleportWithFadeTrue(Transform playerTransform)
    {
        VoiceController.instance.StopMoving();
        transition.SetBool("fading", true);
        yield return new WaitForSeconds(1f);
        soundManager.PlaySound(5);
        CaremaCT5.instance.NextPallet();
        playerTransform.position = teleportDestinationTrue.position;
        yield return new WaitForSeconds(0.8f);
        transition.SetBool("fading", false);
        yield return new WaitForSeconds(0.2f);
    }

    IEnumerator TeleportWithFadeFalse(Transform playerTransform)
    {
        VoiceController.instance.StopMoving();
        transition.SetBool("fading", true);
        yield return new WaitForSeconds(1f);
        soundManager.PlaySound(6);
        gameManagerCT5.instance.dieHearth();
        playerTransform.position = teleportDestinationFalse.position;
        yield return new WaitForSeconds(0.8f);
        transition.SetBool("fading", false);
        yield return new WaitForSeconds(0.2f);
    }
}
