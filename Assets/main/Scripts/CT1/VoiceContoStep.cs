using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceContoStep : MonoBehaviour
{
    [SerializeField] Transform teleportDestination;
    [SerializeField] GameObject stepToConVoice;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            VoiceController.instance.StopMoving();
            VoiceController.instance.continuously = !VoiceController.instance.continuously;
            if (!VoiceController.instance.continuously)
            {
                collision.transform.position = teleportDestination.position;
            }
            VoiceController.instance.stepByStep = !VoiceController.instance.stepByStep;
            gameObject.SetActive(!gameObject.activeInHierarchy);
            stepToConVoice.SetActive(!stepToConVoice.activeInHierarchy);
        }
    }
}
