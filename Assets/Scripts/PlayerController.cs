using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movement = 5f;
    public float JumpHeight = 10f;
    int jumpCount = 0;
    private bool isGrounded;
    private bool jumpPressed;
    private Rigidbody2D rb;
    private float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
    }

    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void HandleInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space)  && jumpCount < 2)
        {
            jumpPressed = true;
        }
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(horizontalInput * movement, rb.linearVelocity.y);
    }

    void Jump()
    {
        if (jumpPressed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpHeight);
            isGrounded = false;
            jumpCount++;
            jumpPressed = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
          
            isGrounded = false;
        }
    }
}