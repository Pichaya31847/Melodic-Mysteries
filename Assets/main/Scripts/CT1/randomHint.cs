using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class randomHint : MonoBehaviour
{
    public GameObject[] gameObjectsHintReal;
    public GameObject[] gameObjectsHintFake;
    public List<string> hintTrue;
    public static GameProgress gameProgress;
    public List<string> hintFake;

    public List<int> objectListReal;
    // Start is called before the first frame update
    void Start()
    {
        hintFake = new List<string>() { "ตะวันออก ด", "ตะวันออก ร", "ตะวันออก ม", "ตะวันออก ฟ", "ตะวันออก ซ", "เหนือ ด", "เหนือ ร", "เหนือ ม", "เหนือ ฟ", "เหนือ ซ", "ใต้ ด", "ใต้ ร", "ใต้ ม", "ใต้ ฟ", "ใต้ ซ", "ตะวันตก ด", "ตะวันตก ร", "ตะวันตก ม", "ตะวันตก ฟ", "ตะวันตก ซ", "ขวา ด", "ขวา ร", "ขวา ม", "ขวา ฟ", "ขวา ซ", "ลง ด", "ลง ร", "ลง ม", "ลง ฟ", "ลง ซ", "ขึ้น ด", "ขึ้น ร", "ขึ้น ม", "ขึ้น ฟ", "ขึ้น ซ", "ซ้าย ด", "ซ้าย ร", "ซ้าย ม", "ซ้าย ฟ", "ซ้าย ซ" };
        gameProgress = SaveLoadManagerGameProgress.LoadGameData();
        hintTrue.Clear();
        if (gameProgress.diffiCult == 1)
        {
            hintTrue = new List<string>() { "เริ่มที่ ฟ", "นับจากล่าง", "ตะวันออก ล", "ใต้ ม", "ขวา ฟ", "เหนือ ซ", "ตะวันออก ร" };
        }
        else if (gameProgress.diffiCult == 2)
        {
            hintTrue = new List<string>() { "เริ่มที่ ร", "นับจากบน", "ตะวันออก ฟ", "ใต้ ม", "ขวา ฟ", "เหนือ ร", "ตะวันออก ร", "ลง ร", "ขวา ร", "เหนือ ร", "สุดท้ายขวา" };
        }
        else if (gameProgress.diffiCult == 3)
        {
            hintTrue = new List<string>() { "เริ่มที่ ล", "นับจากล่าง", "ตะวันออก ซ", "ใต้ ม", "ซ้าย ร", "ล่าง ร", "ตะวันออก ซ", "บน ร", "ตะวันตก ด", "เหนือ ม", "ขวา ท+ร", "ล่าง ม", "ซ้าย ร", "ลง ร", "ตะวันออก ท+ม", "บน ม", "ขวา ซ" };
        }

        objectListReal = new List<int>(new int[gameObjectsHintReal.Length]);
        for (int i = 0; i < gameObjectsHintReal.Length; i++)
        {
            var randomNumberReal = Random.Range(1, hintTrue.Count + 1);
            while (objectListReal.Contains(randomNumberReal))
            {
                randomNumberReal = Random.Range(1, hintTrue.Count + 1);
            }
            objectListReal[i] = randomNumberReal;
            gameObjectsHintReal[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = hintTrue[objectListReal[i] - 1];
            gameObjectsHintReal[i].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = intToRoman.instance.int2roman(objectListReal[i]);
        }
        for (int n = 0; n < gameObjectsHintFake.Length; n++)
        {
            var randomNumberFake = Random.Range(1, hintFake.Count);
            var randomRomanFake = Random.Range(3, 20);
            gameObjectsHintFake[n].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = hintFake[randomNumberFake];
            gameObjectsHintFake[n].transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<TMP_Text>().text = intToRoman.instance.int2roman(randomRomanFake);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
