using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class chestPass : MonoBehaviour
{
    [SerializeField] private GameObject itemUI;
    [SerializeField] private Sprite itemPic;
    public List<string> choose = new List<string>();
    public GameObject[] textAns;
    private int x = 0;
    private int y = 0;
    private int z = 0;
    private int c = 0;
    public List<int> ansWers = new List<int>();
    private Image inventoryImage;
    private TMP_Text inventoryValue;

    // Start is called before the first frame update
    private void Start()
    {
        inventoryImage = itemUI.transform.GetChild(0).GetComponent<Image>();
        inventoryValue = itemUI.transform.GetChild(1).GetComponent<TMP_Text>();
        for (int text = 0; text < textAns.Length; text++)
        {
            TMP_Text[] tmpTextComponents = textAns[text].GetComponents<TMP_Text>();

            foreach (TMP_Text tmpText in tmpTextComponents)
            {
                tmpText.text = "0";
            }
        }
    }
    private void Update()
    {
        if (x == ansWers[0] && y == ansWers[1] && z == ansWers[2] && c == ansWers[3])
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

    public void xplus()
    {
        x += 1;
        if (x == choose.Count)
        {
            x = 0;
            TMP_Text[] tmpTextComponents = textAns[0].GetComponents<TMP_Text>();
            tmpTextComponents[0].text = choose[x].ToString();
        }
        else
        {
            TMP_Text[] tmpTextComponents = textAns[0].GetComponents<TMP_Text>();
            tmpTextComponents[0].text = choose[x].ToString();
        }
    }
    public void xminus()
    {
        x -= 1;
        if (x < 0)
        {
            x = choose.Count - 1;
            TMP_Text[] tmpTextComponents = textAns[0].GetComponents<TMP_Text>();
            tmpTextComponents[0].text = choose[x].ToString();
        }
        else
        {
            TMP_Text[] tmpTextComponents = textAns[0].GetComponents<TMP_Text>();
            tmpTextComponents[0].text = choose[x].ToString();
        }
    }
    public void yplus()
    {
        y += 1;
        if (y == choose.Count)
        {
            y = 0;
            TMP_Text[] tmpTextComponents = textAns[1].GetComponents<TMP_Text>();
            tmpTextComponents[0].text = choose[y].ToString();
        }
        else
        {
            TMP_Text[] tmpTextComponents = textAns[1].GetComponents<TMP_Text>();
            tmpTextComponents[0].text = choose[y].ToString();
        }
    }
    public void yminus()
    {
        y -= 1;
        if (y < 0)
        {
            y = choose.Count - 1;
            TMP_Text[] tmpTextComponents = textAns[1].GetComponents<TMP_Text>();
            tmpTextComponents[0].text = choose[y].ToString();
        }
        else
        {
            TMP_Text[] tmpTextComponents = textAns[1].GetComponents<TMP_Text>();
            tmpTextComponents[0].text = choose[y].ToString();
        }
    }
    public void zplus()
    {
        z += 1;
        if (z == choose.Count)
        {
            z = 0;
            TMP_Text[] tmpTextComponents = textAns[2].GetComponents<TMP_Text>();
            tmpTextComponents[0].text = choose[z].ToString();
        }
        else
        {
            TMP_Text[] tmpTextComponents = textAns[2].GetComponents<TMP_Text>();
            tmpTextComponents[0].text = choose[z].ToString();
        }
    }
    public void zminus()
    {
        z -= 1;
        if (z < 0)
        {
            z = choose.Count - 1;
            TMP_Text[] tmpTextComponents = textAns[2].GetComponents<TMP_Text>();
            tmpTextComponents[0].text = choose[z].ToString();
        }
        else
        {
            TMP_Text[] tmpTextComponents = textAns[2].GetComponents<TMP_Text>();
            tmpTextComponents[0].text = choose[z].ToString();
        }
    }
    public void cplus()
    {
        c += 1;
        if (c == choose.Count)
        {
            c = 0;
            TMP_Text[] tmpTextComponents = textAns[3].GetComponents<TMP_Text>();
            tmpTextComponents[0].text = choose[c].ToString();
        }
        else
        {
            TMP_Text[] tmpTextComponents = textAns[3].GetComponents<TMP_Text>();
            tmpTextComponents[0].text = choose[c].ToString();
        }
    }
    public void cminus()
    {
        c -= 1;
        if (c < 0)
        {
            c = choose.Count - 1;
            TMP_Text[] tmpTextComponents = textAns[3].GetComponents<TMP_Text>();
            tmpTextComponents[0].text = choose[c].ToString();
        }
        else
        {
            TMP_Text[] tmpTextComponents = textAns[3].GetComponents<TMP_Text>();
            tmpTextComponents[0].text = choose[c].ToString();
        }
    }
}

