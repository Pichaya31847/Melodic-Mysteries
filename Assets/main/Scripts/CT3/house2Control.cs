using UnityEngine;

public class house2Control : MonoBehaviour
{
    public placeAble[] textAnsGO;
    [SerializeField] private GameObject tresureRoom;

    private void Start()
    {

    }
    void Update()
    {
        if (AreAllValuesEqual())
        {
            soundManager.PlaySound(5);
            tresureRoom.transform.GetChild(0).gameObject.SetActive(true);
            tresureRoom.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    private bool AreAllValuesEqual()
    {
        for (int i = 0; i < textAnsGO.Length; i++)
        {
            if (textAnsGO[i].correctANS != true)
            {
                return false;
            }
        }

        return true;
    }
}
