using UnityEngine;

public class pickUpItemCT4 : MonoBehaviour
{
    private Vector3 original;
    private float interval = 0f;
    public bool pickUp = false;
    private GameObject placeAble_GO;
    public GameObject player;

    private void Start()
    {
        original = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ResetItem();
        }
        interval -= Time.deltaTime;
        if (pickUp)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E) && !pickUp)
        {
            if (interval > 0) return;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 30;
            Vector3 playerPosition = collision.transform.position;
            transform.position = new Vector3(playerPosition.x, playerPosition.y + 0.5f, playerPosition.z);
            pickUp = true;
            interval = 0.5f;
        }
        if (Input.GetKey(KeyCode.E) && pickUp)
        {
            if (interval > 0) return;
            if (placeAble_GO != null)
            {
                pickUp = false;
                transform.position = placeAble_GO.transform.position;
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
