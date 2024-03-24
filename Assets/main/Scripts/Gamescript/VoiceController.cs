using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows.Speech;

public class VoiceController : MonoBehaviour
{
    public static VoiceController instance;
    public KeywordRecognizer keywordRecognizer;
    public Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private bool Up = false;
    private bool Down = false;
    private bool Next = false;
    private bool Back = false;
    private bool Stop = false;
    public bool continuously = true;
    public bool stepByStep = false;
    public float moveSpeed;
    public bool voiceOpen = false;
    public bool voiceClose = false;
    public bool get = false;
    private string state;
    private int underscoreIndex;
    public bool pickingUp = false;
    public bool placing = false;

    public Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
        state = SceneManager.GetActiveScene().name;
        underscoreIndex = state.IndexOf('_');
        state = state.Substring(0, underscoreIndex);
        keywordActions.Add("top", MoveUp);
        keywordActions.Add("above", MoveUp);
        keywordActions.Add("tob", MoveUp);
        keywordActions.Add("ob", MoveUp);
        keywordActions.Add("op", MoveUp);
        keywordActions.Add("up", MoveUp);
        keywordActions.Add("under", MoveDown);
        keywordActions.Add("down", MoveDown);
        keywordActions.Add("drown", MoveDown);
        keywordActions.Add("front", MoveFront);
        keywordActions.Add("font", MoveFront);
        keywordActions.Add("fon", MoveFront);
        keywordActions.Add("next", MoveFront);
        keywordActions.Add("nex", MoveFront);
        keywordActions.Add("net", MoveFront);
        keywordActions.Add("neck", MoveFront);
        keywordActions.Add("back", MoveBack);
        keywordActions.Add("run", RunMoving);
        keywordActions.Add("walk", WalkMoving);
        keywordActions.Add("stop", StopMoving);
        keywordActions.Add("get", GetIt);
        keywordActions.Add("open", open);
        keywordActions.Add("close", close);
        keywordActions.Add("pickup", pickUp);
        keywordActions.Add("pick", pickUp);
        keywordActions.Add("putdown", place);


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
        if (continuously)
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
        else if (stepByStep)
        {

            if (state == "CT1")
            {
                if (!DOTween.IsTweening(transform))
                {
                    if (Up)
                    {
                        transform.DOMove(transform.position + new Vector3(0, 2, 0), 0.5f).OnComplete(() => StopMoving());
                    }
                    if (Down)
                    {
                        transform.DOMove(transform.position + new Vector3(0, -2, 0), 0.5f).OnComplete(() => StopMoving());
                    }
                    if (Next)
                    {
                        transform.DOMove(transform.position + new Vector3(2, 0, 0), 0.5f).OnComplete(() => StopMoving());
                    }
                    if (Back)
                    {
                        transform.DOMove(transform.position + new Vector3(-2, 0, 0), 0.5f).OnComplete(() => StopMoving());
                    }
                }
            }
            else if (state == "CT4")
            {
                if (!DOTween.IsTweening(transform))
                {
                    if (Up)
                    {
                        transform.DOMove(transform.position + new Vector3(0, 1, 0), 0.5f).OnComplete(() => StopMoving());
                    }
                    if (Down)
                    {
                        transform.DOMove(transform.position + new Vector3(0, -1, 0), 0.5f).OnComplete(() => StopMoving());
                    }
                    if (Next)
                    {
                        transform.DOMove(transform.position + new Vector3(1, 0, 0), 0.5f).OnComplete(() => StopMoving());
                    }
                    if (Back)
                    {
                        transform.DOMove(transform.position + new Vector3(-1, 0, 0), 0.5f).OnComplete(() => StopMoving());
                    }
                }
            }
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

    public void StopMoving()
    {
        Up = false;
        Down = false;
        Next = false;
        Back = false;
        Stop = true;
    }

    private void RunMoving()
    {
        moveSpeed += 3f;
    }
    private void WalkMoving()
    {
        moveSpeed -= 3f;
    }
    private void open()
    {
        voiceOpen = true;
    }
    private void close()
    {
        voiceClose = true;
    }
    private void GetIt()
    {
        get = true;
    }
    private void pickUp()
    {
        StartCoroutine(PickUpCoroutine(2));
    }
    private IEnumerator PickUpCoroutine(float seconds)
    {
        pickingUp = true;
        yield return new WaitForSeconds(seconds);
        pickingUp = false;
    }
    private void place()
    {
        StartCoroutine(PlaceCoroutine(2));
    }
    private IEnumerator PlaceCoroutine(float seconds)
    {
        placing = true;
        yield return new WaitForSeconds(seconds);
        placing = false;
    }

    private void Awake()
    {
        instance = this;
    }
}
