using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class musicPass : MonoBehaviour
{
    [SerializeField] private GameObject itemUI;
    [SerializeField] private Sprite itemPic;
    public List<string> choose = new List<string>();
    private int[] values = new int[16];
    public GameObject[] textAns;
    public List<int> ansWers = new List<int>();
    private Image inventoryImage;
    private TMP_Text inventoryValue;


    private void Start()
    {
        inventoryImage = itemUI.transform.GetChild(0).GetComponent<Image>();
        inventoryValue = itemUI.transform.GetChild(1).GetComponent<TMP_Text>();
        for (int text = 0; text < textAns.Length; text++)
        {
            TMP_Text[] tmpTextComponents = textAns[text].GetComponents<TMP_Text>();
            foreach (TMP_Text tmpText in tmpTextComponents)
            {
                tmpText.text = "-";
            }
        }
    }

    private void Update()
    {
        if (AreAllValuesEqual())
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

    public void Plus(int index)
    {
        values[index] += 1;
        if (values[index] == choose.Count)
        {
            values[index] = 0;
        }

        UpdateText(index);
    }

    public void Minus(int index)
    {
        values[index] -= 1;
        if (values[index] < 0)
        {
            values[index] = choose.Count - 1;
        }

        UpdateText(index);
    }

    private void UpdateText(int index)
    {
        TMP_Text[] tmpTextComponents = textAns[index].GetComponents<TMP_Text>();
        tmpTextComponents[0].text = choose[values[index]].ToString();
    }

    private bool AreAllValuesEqual()
    {
        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] != ansWers[i])
            {
                return false;
            }
        }

        return true;
    }

}
