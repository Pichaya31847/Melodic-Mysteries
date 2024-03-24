using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class activateturei : MonoBehaviour
{
    public TMP_Text text;
    public List<string> textChats;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (textChats != null && textChats.Count > 0)
            {
                string combinedText = string.Join("\n", textChats);
                text.text = combinedText;
            }
        }
    }
}
