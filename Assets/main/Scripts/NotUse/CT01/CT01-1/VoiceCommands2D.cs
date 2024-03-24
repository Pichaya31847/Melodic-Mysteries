using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Collections.Generic;
using System.Linq;

public class VoiceCommands2D : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();

    public bool hitCorider = false;
    private bool Up = false;
    private bool Down = false;
    private bool Next = false;
    private bool Back = false;
    private bool Stop = false;
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    void Start()
    {
        keywordActions.Add("top", MoveUp);
        keywordActions.Add("under", MoveDown);
        keywordActions.Add("next", MoveFront);
        keywordActions.Add("back", MoveBack);
        keywordActions.Add("run", RunMoving);
        keywordActions.Add("walk", WalkMoving);
        keywordActions.Add("stop", StopMoving);
        keywordActions.Add("pick up", Pickup);
        keywordActions.Add("close", CloseEverything);
        keywordActions.Add("inventory", InventoryOpen);
        keywordActions.Add("one", () => { HandleNumber(1); });
        keywordActions.Add("two", () => { HandleNumber(2); });
        keywordActions.Add("three", () => { HandleNumber(3); });
        keywordActions.Add("four", () => { HandleNumber(4); });
        keywordActions.Add("five", () => { HandleNumber(5); });
        keywordActions.Add("six", () => { HandleNumber(6); });
        keywordActions.Add("seven", () => { HandleNumber(7); });
        keywordActions.Add("eight", () => { HandleNumber(8); });
        keywordActions.Add("nine", () => { HandleNumber(9); });
        keywordActions.Add("delete", DeleteText);
        keywordActions.Add("submit", SubmitText);
        keywordActions.Add("hole", digrock);
        keywordActions.Add("open", OpenHintUI);


        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        Action keywordAction;
        if (keywordActions.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
            Debug.Log(args.text);
        }
    }
    void Update()
    {
        if (Up)
        {
            PlayerController.instance.keydown = false;
            animator.SetFloat("Speed", moveSpeed);
            animator.SetFloat("YInput", 1);
            animator.SetFloat("XInput", 0);
            animator.SetFloat("vertical", 1);
            animator.SetFloat("horizontal", 0);
        }
        else if (Down)
        {
            PlayerController.instance.keydown = false;
            animator.SetFloat("Speed", moveSpeed);
            animator.SetFloat("YInput", -1);
            animator.SetFloat("XInput", 0);
            animator.SetFloat("vertical", -1);
            animator.SetFloat("horizontal", 0);
        }
        else if (Next)
        {
            PlayerController.instance.keydown = false;
            animator.SetFloat("Speed", moveSpeed);
            animator.SetFloat("YInput", 0);
            animator.SetFloat("XInput", 1);
            animator.SetFloat("vertical", 0);
            animator.SetFloat("horizontal", 1);
        }
        else if (Back)
        {
            PlayerController.instance.keydown = false;
            animator.SetFloat("Speed", moveSpeed);
            animator.SetFloat("YInput", 0);
            animator.SetFloat("XInput", -1);
            animator.SetFloat("vertical", 0);
            animator.SetFloat("horizontal", -1);
        }
        else if (Stop)
        {
            PlayerController.instance.keydown = false;
            animator.SetFloat("Speed", 0);
            animator.SetFloat("YInput", 0);
            animator.SetFloat("XInput", 0);
            Stop = false;
            PlayerController.instance.keydown = true;
        }
    }

    void FixedUpdate()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        if (Up)
        {
            y += moveSpeed * Time.fixedDeltaTime;
            transform.position = new Vector3(x, y, 0);
        }
        if (Down)
        {
            y -= moveSpeed * Time.fixedDeltaTime;
            transform.position = new Vector3(x, y, 0);
        }
        if (Next)
        {
            x += moveSpeed * Time.fixedDeltaTime;
            transform.position = new Vector3(x, y, 0);
        }
        if (Back)
        {
            x -= moveSpeed * Time.fixedDeltaTime;
            transform.position = new Vector3(x, y, 0);
        }
    }

    private void MoveUp()
    {
        Up = true;
        Down = false;
        Next = false;
        Back = false;
        Stop = false;
    }

    private void MoveDown()
    {
        Up = false;
        Down = true;
        Next = false;
        Back = false;
        Stop = false;
    }

    private void MoveFront()
    {
        Up = false;
        Down = false;
        Next = true;
        Back = false;
        Stop = false;
    }

    private void MoveBack()
    {
        Up = false;
        Down = false;
        Next = false;
        Back = true;
        Stop = false;
    }

    private void StopMoving()
    {
        Up = false;
        Down = false;
        Next = false;
        Back = false;
        Stop = true;
    }

    private void RunMoving()
    {
        moveSpeed = 9f;
    }
    private void WalkMoving()
    {
        moveSpeed = 5f;
    }

    private void Pickup()
    {
        PlayerController.instance.VoicePickup = !PlayerController.instance.VoicePickup;
        Invoke(nameof(InvokePickup), 0.5f);
    }

    private void Interact()
    {
        LockPassword.instance.InteractOpenUI();
    }

    private void CloseEverything()
    {
        LockPassword.instance.CloseOpenUI();
        GameManager.Instance.CloseInventory();
        hintShow.Instance.SpeekCloseUI();
    }

    private void InvokePickup()
    {
        PlayerController.instance.VoicePickup = !PlayerController.instance.VoicePickup;
    }

    private void InventoryOpen()
    {
        GameManager.Instance.OpenInventory();
    }

    private void HandleNumber(int number)
    {
        LockPassword.instance.passwordInput.text += number.ToString();
    }

    private void DeleteText()
    {
        if (LockPassword.instance.passwordInput.text.Length != 0)
        {
            LockPassword.instance.passwordInput.text = LockPassword.instance.passwordInput.text.Substring(0, LockPassword.instance.passwordInput.text.Length - 1);
        }
    }

    private void SubmitText()
    {
        LockPassword.instance.CheckedPassWord();
    }

    private void digrock()
    {
        BreakItem.instance.digSpeek();
    }

    private void OpenHintUI()
    {
        if (LockPassword.instance.hitCorider) { Interact(); }
        else if (hitCorider)
        {
            hintShow.Instance.SpeekOpenUI();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hintstate"))
        {
            hitCorider = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hintstate"))
        {
            hitCorider = false;
        }
    }

}
