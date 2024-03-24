using UnityEngine;

public class placeMentCT4 : MonoBehaviour
{
    public bool correctANS = false;
    private pickUpItemCT4 pickUpItem;
    private void Update()
    {
        if (pickUpItem != null)
        {
            if (pickUpItem.pickUp)
            {
                correctANS = false;
            }
            else
            {
                correctANS = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pickUpItem"))
        {
            collision.gameObject.TryGetComponent(out pickUpItem);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pickUpItem"))
        {
            if (pickUpItem.pickUp)
            {
                correctANS = false;
                pickUpItem = null;
            }
        }
    }
}
