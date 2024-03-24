using System.Collections;
using UnityEngine;

public class teleportToPosition : MonoBehaviour
{
    [SerializeField] Transform teleportDestination;
    [SerializeField] Animator transition;
    public int faceWalkX;
    public int faceWalkY;
    private bool isActive = false;
    private void OnTriggerEnter2D(Collider2D other)
    {

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (!isActive)
            {
                StartCoroutine(TeleportWithFade(other.transform));
                Invoke("ActiveOrNot", 0.3f);
            }
            else if (isActive)
            {
                Invoke("ActiveOrNot", 0.3f);
            }
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            if (VoiceController.instance.get)
            {
                if (!isActive)
                {
                    StartCoroutine(TeleportWithFade(other.transform));
                    Invoke("ActiveOrNot", 0.3f);
                }
                else if (isActive)
                {
                    Invoke("ActiveOrNot", 0.3f);
                }
                VoiceController.instance.get = false;
            }
        }
    }
    IEnumerator TeleportWithFade(Transform playerTransform)
    {
        VoiceController.instance.StopMoving();
        transition.SetBool("fading", true);
        yield return new WaitForSeconds(1f);
        playerTransform.position = teleportDestination.position;
        yield return new WaitForSeconds(0.8f);
        transition.SetBool("fading", false);
        PlayerController.instance.StartPositionFaceX = faceWalkX;
        PlayerController.instance.StartPositionFaceY = faceWalkY;
        PlayerController.instance.updatePosition();
        yield return new WaitForSeconds(0.2f);
    }
    private void ActiveOrNot()
    {
        isActive = !isActive;
    }
}
