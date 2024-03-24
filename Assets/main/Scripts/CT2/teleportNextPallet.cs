using System.Collections;
using UnityEngine;

public class teleportNextPallet : MonoBehaviour
{
    [SerializeField] Transform teleportDestination;
    [SerializeField] Animator transition;
    public int faceWalkX;
    public int faceWalkY;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(TeleportWithFade(other.transform));
        }
    }
    IEnumerator TeleportWithFade(Transform playerTransform)
    {
        VoiceController.instance.StopMoving();
        transition.SetBool("fading", true);
        yield return new WaitForSeconds(1f);
        PlayerController.instance.StartPositionFaceX = faceWalkX;
        PlayerController.instance.StartPositionFaceY = faceWalkY;
        PlayerController.instance.updatePosition();
        playerTransform.position = teleportDestination.position;
        yield return new WaitForSeconds(0.8f);
        transition.SetBool("fading", false);
        yield return new WaitForSeconds(0.2f);
    }
}

