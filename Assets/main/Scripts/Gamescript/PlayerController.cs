using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public static PlayerController instance;
    public bool VoicePickup = false;
    public Rigidbody2D rb;
    public Animator animator;
    public bool keydown = true;
    public float StartPositionFaceX;
    public float StartPositionFaceY;
    public bool Pickaxe;
    public float xPosition;
    public float yPosition;

    Vector2 movement;

    private void Start()
    {
        animator.SetFloat("vertical", StartPositionFaceY);
        animator.SetFloat("horizontal", StartPositionFaceX);
    }

    private void Update()
    {
        xPosition = transform.position.x;
        yPosition = transform.position.y;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed += 3;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed -= 3;
        }

        if (keydown)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("XInput", movement.x);
            animator.SetFloat("YInput", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetFloat("horizontal", movement.x);
            animator.SetFloat("vertical", movement.y);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetFloat("horizontal", movement.x);
            animator.SetFloat("vertical", movement.y);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetFloat("horizontal", movement.x);
            animator.SetFloat("vertical", movement.y);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetFloat("horizontal", movement.x);
            animator.SetFloat("vertical", movement.y);
        }

        if (Pickaxe)
        {
            animator.SetTrigger("Dig");
            Pickaxe = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    public void updatePosition()
    {
        animator.SetFloat("vertical", StartPositionFaceY);
        animator.SetFloat("horizontal", StartPositionFaceX);
    }

    private void Awake()
    {
        instance = this;
    }
}