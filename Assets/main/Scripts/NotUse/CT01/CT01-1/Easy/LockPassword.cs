using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockPassword : MonoBehaviour
{
    public static LockPassword instance;
    [SerializeField] private GameObject passWordUI;
    [SerializeField] private GameObject textHint;
    [SerializeField] private GameObject barieCanBreak;
    [SerializeField] private GameObject passWordParticle;
    [SerializeField] public TMPro.TMP_InputField passwordInput;
    public string passText = "";
    public string ResultText;
    private bool uiOpen = false;
    private bool passState = false;
    public bool hitCorider = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ResultText = ItemDrop.Instance.ResultItemRandom.ToString();
        passText = passwordInput.text;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !uiOpen && !passState)
        {
            hitCorider = true;
            textHint.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKey(KeyCode.E) && !passState)
        {
            if (!uiOpen)
            {
                textHint.SetActive(false);
                passWordUI.SetActive(true);
                Invoke("uiIsopen", 0.3f);
            }
            else if (uiOpen)
            {
                textHint.SetActive(true);
                passWordUI.SetActive(false);
                Invoke("uiNotopen", 0.3f);
            }
        }
        if (other.gameObject.CompareTag("Player") && Input.GetKey("enter") && uiOpen)
        {
            hitCorider = false;
            CheckedPassWord();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !uiOpen && !passState)
        {
            textHint.SetActive(false);
        }
    }

    void uiIsopen()
    {
        uiOpen = true;
        PlayerController.instance.keydown = false;
    }
    void uiNotopen()
    {
        uiOpen = false;
        PlayerController.instance.keydown = true;
    }

    public void CheckedPassWord()
    {
        if (passText == ResultText)
        {
            PlayerController.instance.keydown = true;
            passWordUI.SetActive(false);
            textHint.SetActive(false);
            Destroy(passWordParticle);
            Destroy(barieCanBreak);
        }
    }

    public void InteractOpenUI()
    {
        textHint.SetActive(false);
        passWordUI.SetActive(true);
        Invoke("uiIsopen", 0.3f);
    }

    public void CloseOpenUI(){
        textHint.SetActive(true);
        passWordUI.SetActive(false);
        Invoke("uiNotopen", 0.3f);
    }

    private void Awake()
    {
        instance = this;
    }
    
}
