using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGold : MonoBehaviour
{
    [SerializeField] private GameObject hintEasy;
    private bool Dig = true;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E) && Dig && InventoryManager.Instance.iteminventories.ContainsKey("pickaxe"))
        {
            PlayerController.instance.Pickaxe = true;
            Dig = false;
            Invoke("Destroy_Item", 0.3f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }
    }

    public void Destroy_Item()
    {
        hintEasy.SetActive(true);
        Destroy(gameObject);
        Dig = true;
    }
}
