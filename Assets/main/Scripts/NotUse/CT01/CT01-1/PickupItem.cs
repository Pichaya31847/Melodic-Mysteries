using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private GameObject pickUpText;
    private bool pickUpAllowed;

    // Use this for initialization
    private void Start()
    {
        pickUpText.SetActive(false);
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pickUpAllowed = true;
            pickUpText.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (pickUpAllowed && Input.GetKey(KeyCode.E))
            PickUp(name);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pickUpAllowed = false;
            pickUpText.SetActive(false);
        }
    }

    private void PickUp(string itemAdd)
    {
        InventoryManager.Instance.AddItems(itemAdd);
        Destroy(gameObject);
        Debug.Log(InventoryManager.Instance.iteminventories[itemAdd]);
    }
}
