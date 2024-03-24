using UnityEngine;

public class placeAble : MonoBehaviour
{
    private string o_name;
    public bool correctANS = false;
    private pickUpItem pickUpItem;
    private void Start()
    {
        o_name = gameObject.name.Replace("place", "");
    }
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
        if (collision.gameObject.CompareTag("pickUpItem") && collision.name == o_name)
        {
            collision.gameObject.TryGetComponent(out pickUpItem);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("pickUpItem") && collision.name == o_name)
        {
            if (pickUpItem.pickUp)
            {
                correctANS = false;
                pickUpItem = null;
            }
        }
    }
}
