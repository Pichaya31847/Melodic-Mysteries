using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ItemPickup"))
        {
            collision.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (collision.gameObject.CompareTag("WallCanBreak"))
        {
            collision.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (collision.gameObject.CompareTag("PasswordBarrie"))
        {
            collision.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ItemPickup") && (Input.GetKey(KeyCode.E) || PlayerController.instance.VoicePickup))
        {
            PickUp(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ItemPickup"))
        {
            collision.transform.GetChild(1).gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("WallCanBreak"))
        {
            collision.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    private void PickUp(GameObject itemAdd)
    {
        if (itemAdd.activeInHierarchy)
        {
            itemAdd.SetActive(false);
            InventoryManager.Instance.AddItems(itemAdd.name);
            Destroy(itemAdd);
            Debug.Log(InventoryManager.Instance.iteminventories[itemAdd.name]);
        }
    }
}
