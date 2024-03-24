using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public List<int> RanItemDrop;
    public int ResultItemRandom = 0;
    public static ItemDrop Instance;
    public string Operations;
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < 10; i++)
        {
            int Num = Random.Range(1, 8);
            RanItemDrop.Add(Num);
            ResultItemRandom += Num;
        }
        int Operation = Random.Range(1, 2);
        if (Operation == 1) { Operations = "+"; } else { Operations = "-"; }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        Instance = this;
    }
}
