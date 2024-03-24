using TMPro;
using UnityEngine;

public class pickUpItem : MonoBehaviour
{
    private Vector3 original;
    private float interval = 0f;
    public bool pickUp = false;
    public string nameGO;
    private GameObject placeAble_GO;
    [SerializeField] private GameObject textUI;
    private TMP_Text tMP_Text;

    private void Start()
    {
        tMP_Text = textUI.transform.GetChild(0).GetComponent<TMP_Text>();
        original = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetItem();
        }
        interval -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E) && !pickUp)
        {
            if (interval > 0) return;
            tMP_Text.text = nameGO;
            textUI.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 30;
            Vector3 playerPosition = collision.transform.position;
            transform.position = new Vector3(playerPosition.x, playerPosition.y + 0.5f, playerPosition.z);
            pickUp = true;
            interval = 0.5f;
        }
        else if (collision.gameObject.CompareTag("Player") && pickUp)
        {
            Vector3 playerPosition = collision.transform.position;
            transform.position = new Vector3(playerPosition.x, playerPosition.y + 0.5f, playerPosition.z);
        }
        if (Input.GetKey(KeyCode.E) && pickUp)
        {
            if (interval > 0) return;
            textUI.SetActive(false);
            if (placeAble_GO != null)
            {
                pickUp = false;
                transform.position = placeAble_GO.transform.position;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 6;
                interval = 0.5f;
            }
            else
            {
                transform.position = original;
                pickUp = false;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 6;
                interval = 0.5f;
            }
        }
        if (collision.gameObject.CompareTag("Player") && VoiceController.instance.pickingUp && !pickUp)
        {
            if (interval > 0) return;
            VoiceController.instance.pickingUp = false;
            tMP_Text.text = nameGO;
            textUI.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 30;
            Vector3 playerPosition = collision.transform.position;
            transform.position = new Vector3(playerPosition.x, playerPosition.y + 0.5f, playerPosition.z);
            pickUp = true;
            interval = 0.5f;
        }
        if (VoiceController.instance.placing && pickUp)
        {
            if (interval > 0) return;
            VoiceController.instance.placing = false;
            textUI.SetActive(false);
            if (placeAble_GO != null)
            {
                pickUp = false;
                transform.position = placeAble_GO.transform.position;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 6;
                interval = 0.5f;
            }
            else
            {
                transform.position = original;
                pickUp = false;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 6;
                interval = 0.5f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("placeAble"))
        {
            placeAble_GO = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("placeAble"))
        {
            if (placeAble_GO != null)
            {
                if (placeAble_GO == collision.gameObject)
                {
                    placeAble_GO = null;
                }
            }
        }
    }

    void ResetItem()
    {
        transform.position = original;
        pickUp = false;
        gameObject.layer = 6;
    }
}
