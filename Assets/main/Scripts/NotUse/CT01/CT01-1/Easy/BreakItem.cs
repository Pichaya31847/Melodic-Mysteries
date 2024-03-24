using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakItem : MonoBehaviour
{
    public static BreakItem instance;
    private bool Dig = true;
    private bool digvoice = false;
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
        }if (other.gameObject.CompareTag("Player") && digvoice && Dig && InventoryManager.Instance.iteminventories.ContainsKey("pickaxe"))
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
        GameManager.Instance.CheckItemDrop(name);
        Destroy(gameObject);
        Dig = true;
    }

    public void DestroyItemVoice()
    {
        if (InventoryManager.Instance.iteminventories.ContainsKey("pickaxe"))
        {
            PlayerController.instance.Pickaxe = true;
            Dig = false;
            Invoke("Destroy_Item", 0.3f);
        }
    }

    public void digSpeek()
    {
        digvoice = true;
    }

    private void Awake()
    {
        instance = this;
    }
}
