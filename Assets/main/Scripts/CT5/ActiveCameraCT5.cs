using UnityEngine;

public class ActiveCameraCT5 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CaremaCT5.instance.NextPallet();
        }
    }
}
