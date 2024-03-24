using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<Image> images;
    public List<Image> imagesBag;
    public Dictionary<string, TMPro.TextMeshProUGUI> numPresent = new Dictionary<string, TMPro.TextMeshProUGUI>();
    public Dictionary<string, TMPro.TextMeshProUGUI> numPresentBag = new Dictionary<string, TMPro.TextMeshProUGUI>();
    public static InventoryManager Instance;
    public Dictionary<string, int> iteminventories = new Dictionary<string, int>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    public void AddItems(string itemAdd)
    {
        if (itemAdd.Contains("main")) { 
            
         }
        else
        {
            if (iteminventories.ContainsKey(itemAdd))
            {
                iteminventories[itemAdd]++;
                numPresent[itemAdd].text = iteminventories[itemAdd].ToString();
                numPresentBag[itemAdd].text = iteminventories[itemAdd].ToString();
            }
            else
            {
                iteminventories.Add(itemAdd, 1);
                AssignItem(itemAdd);
            }
        }
    }

    public void AssignItem(string itemAdd)
    {
        foreach (Image image in images)
        {
            if (image.sprite == null)
            {
                image.sprite = Resources.Load<Sprite>(itemAdd);
                image.color = Color.white;
                TMPro.TextMeshProUGUI numText = image.transform.parent.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                numText.text = iteminventories[itemAdd].ToString();
                numPresent.Add(itemAdd, numText);
                break;
            }
        }
        foreach (Image images in imagesBag)
        {
            if (images.sprite == null)
            {
                images.sprite = Resources.Load<Sprite>(itemAdd);
                images.color = Color.white;
                TMPro.TextMeshProUGUI numText = images.transform.parent.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                numText.text = iteminventories[itemAdd].ToString();
                numPresentBag.Add(itemAdd, numText);
                break;
            }
        }
    }

    public void ClearItem()
    {
        foreach (Image image in images)
        {
            if (image.sprite == null)
            {
                image.sprite = null;
                image.color = new Color(0, 0, 0, 0);
                TMPro.TextMeshProUGUI numText = image.transform.parent.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                numText.text = "";
                break;
            }
        }
        foreach (Image images in imagesBag)
        {
            if (images.sprite == null)
            {
                images.sprite = null;
                images.color = new Color(0, 0, 0, 0);
                TMPro.TextMeshProUGUI numText = images.transform.parent.GetComponentInChildren<TMPro.TextMeshProUGUI>();
                numText.text = "";
                break;
            }
        }
        numPresentBag.Clear();
        numPresent.Clear();
        iteminventories.Clear();
    }

}
