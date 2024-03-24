using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hintShow : MonoBehaviour
{
    [SerializeField] private GameObject hintEasyUI;
    [SerializeField] private GameObject Hintparticle;
    public static hintShow Instance;
    private bool uiOpen = false;
    public bool hitCorider = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hitCorider=true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            if (!uiOpen)
            {
                hintEasyUI.SetActive(true);
                Hintparticle.SetActive(false);
                Invoke("uiIsopen", 0.3f);
            }
            else if (uiOpen)
            {
                hintEasyUI.SetActive(false);
                Invoke("uiNotopen", 0.3f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hintEasyUI.SetActive(false);
            hitCorider=false;
            uiNotopen();
        }
    }

    void uiIsopen()
    {
        uiOpen = true;
    }
    void uiNotopen()
    {
        uiOpen = false;
    }

    public void SpeekOpenUI()
    {
        hintEasyUI.SetActive(true);
        Hintparticle.SetActive(false);
        Invoke("uiIsopen", 0.3f);
    }
    public void SpeekCloseUI()
    {
        hintEasyUI.SetActive(false);
        Invoke("uiNotopen", 0.3f);
    }

    private void Awake()
    {
        Instance = this;
    }
}
