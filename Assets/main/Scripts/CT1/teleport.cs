using UnityEngine;
using DG.Tweening;

public class teleport : MonoBehaviour
{
    [SerializeField] Transform teleportDestination;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DOTween.Clear();
            other.transform.position = teleportDestination.position;
            GameManagerCT1.instance.FailWalkCount();
        }
    }
}
