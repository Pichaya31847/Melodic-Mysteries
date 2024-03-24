using System.Collections.Generic;
using UnityEngine;

public class scoreUI : MonoBehaviour
{
    public rowUI rowUI;
    public GameObject dataNotFound;
    private List<ScoreCurrrentData> dataList;
    private void Start()
    {
        dataList = SaveLoadScore.LoadData();
        for (int i = 0; i < dataList.Count; i++)
        {
            var row = Instantiate(rowUI, transform).GetComponent<rowUI>();
            row.difficult.text = dataList[i].diffiCult.ToString();
            row.state1.text = dataList[i].state1.ToString();
            row.state2.text = dataList[i].state2.ToString();
            row.state3.text = dataList[i].state3.ToString();
            row.state4.text = dataList[i].state4.ToString();
            row.state5.text = dataList[i].state5.ToString();
            float avgScore = (dataList[i].state1 + dataList[i].state2 + dataList[i].state3 + dataList[i].state4 + dataList[i].state5) / 5;
            row.avg.text = avgScore.ToString();
        }
        if (dataList.Count == 0)
        {
            dataNotFound.SetActive(true);
        }
    }
}
