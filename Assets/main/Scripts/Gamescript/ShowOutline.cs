using UnityEngine;

public class ShowOutline : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (this.transform.GetChild(0).CompareTag("Outline"))
            {
                this.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (this.transform.GetChild(0).CompareTag("Outline"))
            {
                this.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
