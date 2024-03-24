using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject BorderKeydown;
    [SerializeField] private GameObject BorderSpeek;
    [SerializeField] private GameObject InventoryBar;
    [SerializeField] private GameObject openInventoryBag;
    [SerializeField] public List<GameObject> Iron;
    [SerializeField] public List<GameObject> Gold;
    public List<int> RanNum;
    public bool inventoryStatus = false;

    public static GameManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        InventoryBar.SetActive(true);
        BorderKeydown.SetActive(true);
        for (int i = 0; i < 11; i++)
        {
            CheckAndAddRanNum();
            Debug.Log(RanNum.Count);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerController.instance.keydown)
        {
            BorderKeydown.SetActive(false);
            BorderSpeek.SetActive(true);
        }
        else
        {
            BorderKeydown.SetActive(true);
            BorderSpeek.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!inventoryStatus)
            {
                InventoryBar.SetActive(false);
                openInventoryBag.SetActive(true);
                inventoryStatus = true;
            }
            else
            {
                InventoryBar.SetActive(true);
                openInventoryBag.SetActive(false);
                inventoryStatus = false;
            }
        }
    }

    void CheckAndAddRanNum()
    {
        int Num = UnityEngine.Random.Range(0, Iron.Count);
        if (!RanNum.Contains(Num + 1))
        {
            RanNum.Add(Num + 1);
        }
        else
        {
            CheckAndAddRanNum();
        }
    }

    public void CheckItemDrop(string ItemName)
    {
        int ItemNameNum = int.Parse(ItemName);
        for (int i = 0; i < RanNum.Count; i++)
        {
            if (RanNum[i] == ItemNameNum)
            {
                if (i == 10)
                {
                    GameObject opperationPrefab = Resources.Load<GameObject>($"CT1-01/{ItemDrop.Instance.Operations}");
                    GameObject opperationDrop = Instantiate(opperationPrefab, Iron[ItemNameNum - 1].transform.position, Quaternion.identity);
                    opperationDrop.name = $"CT1-01/{ItemDrop.Instance.Operations}";
                    break;
                }
                else
                {
                    Debug.Log(i);
                    Debug.Log(RanNum[i]);
                    Debug.Log(ItemDrop.Instance.RanItemDrop[i]);
                    GameObject prefabsItem = Resources.Load<GameObject>($"CT1-01/{ItemDrop.Instance.RanItemDrop[i]}");
                    GameObject itemDrop = Instantiate(prefabsItem, Iron[ItemNameNum - 1].transform.position, Quaternion.identity);
                    itemDrop.name = $"CT1-01/{ItemDrop.Instance.RanItemDrop[i]}";
                    break;
                }
            }
        }
    }

    public void OpenInventory()
    {
        openInventoryBag.SetActive(true);
    }

    public void CloseInventory()
    {
        openInventoryBag.SetActive(false);
    }

    private void Awake()
    {
        Instance = this;
    }
}
