using TMPro;
using UnityEngine;

public class showTextAndDestroy : MonoBehaviour
{
    [SerializeField] private GameObject textUI;
    public string textChat;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        textUI.SetActive(true);
        textUI.transform.GetChild(0).GetComponent<TMP_Text>().text = textChat;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        textUI.SetActive(false);
        Destroy(gameObject);
    }
}
