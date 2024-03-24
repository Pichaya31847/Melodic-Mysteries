using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class pickupItemCT3 : MonoBehaviour
{
    [SerializeField] private GameObject itemUI;
    [SerializeField] private Sprite itemPic;
    private Image inventoryImage;
    private TMP_Text inventoryValue;
    private void Start()
    {
        inventoryImage = itemUI.transform.GetChild(0).GetComponent<Image>();
        inventoryValue = itemUI.transform.GetChild(1).GetComponent<TMP_Text>();
    }
    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            itemUI.SetActive(true);
            if (itemPic.name == inventoryImage.sprite.name)
            {
                int currentValue = int.Parse(inventoryValue.text);
                inventoryValue.text = (currentValue + 1).ToString();
            }
            else
            {
                inventoryImage.sprite = itemPic;
                inventoryValue.text = "1";
            }
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            if (VoiceController.instance.get)
            {
                itemUI.SetActive(true);
                if (itemPic.name == inventoryImage.sprite.name)
                {
                    int currentValue = int.Parse(inventoryValue.text);
                    inventoryValue.text = (currentValue + 1).ToString();
                }
                else
                {
                    inventoryImage.sprite = itemPic;
                    inventoryValue.text = "1";
                }
                Destroy(gameObject);
                VoiceController.instance.get = false;
            }
        }
    }
}
