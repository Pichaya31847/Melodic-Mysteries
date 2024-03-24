using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class chestNoPass : MonoBehaviour
{
    [SerializeField] private GameObject itemUI;
    [SerializeField] private Sprite itemPic;
    private Image inventoryImage;
    private TMP_Text inventoryValue;
    // Start is called before the first frame update
    private void Start()
    {
        inventoryImage = itemUI.transform.GetChild(0).GetComponent<Image>();
        inventoryValue = itemUI.transform.GetChild(1).GetComponent<TMP_Text>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            soundManager.PlaySound(5);
            transform.parent.GetChild(1).gameObject.SetActive(true);
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
    }
}
