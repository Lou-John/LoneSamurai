using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    float moveSpeed = 5f;
    bool isFacingRight = false;
    float jumpPower = 5f;
    bool isGrounded = false;
    float distToGround;

    // Button movements
    public Button upButton;
    public Button rightButton;
    public Button leftButton;

    // Level reset position
    public Vector3 teleportPosition = new Vector3(-12f, -12f, 0f);

    public Canvas GameOver;


    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        distToGround = 0.1f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        upButton.onClick.AddListener(MoveUp);
        rightButton.onClick.AddListener(MoveRight);
        leftButton.onClick.AddListener(MoveLeft);
    }

    // Update is called once per frame
    void Update()
    {
        HandleTouchInput();
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        FlipSprite();

        if (verticalInput > 0 && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            // Do not set isGrounded to false here
            animator.SetBool("isJumping", true);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
        Debug.Log(horizontalInput);
    }

    void FlipSprite()
    {
        if (isFacingRight && horizontalInput < 0f || !isFacingRight && horizontalInput > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    void MoveUp()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            animator.SetBool("isJumping", true);
        }
    }

    void MoveRight()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void MoveLeft()
    {
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    // Handle touch input for buttons
    void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    CheckButtonTouch(touch.position);
                    break;
            }
        }
    }

    // Check which button was touched
    void CheckButtonTouch(Vector2 touchPosition)
    {
        if (upButton.GetComponent<RectTransform>().rect.Contains(touchPosition))
        {
            MoveUp();
        }
        else if (rightButton.GetComponent<RectTransform>().rect.Contains(touchPosition))
        {
            MoveRight();
        }
        else if (leftButton.GetComponent<RectTransform>().rect.Contains(touchPosition))
        {
            MoveLeft();
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "FIN 1":
                Debug.Log(collision.gameObject.name);
                MyEvents.InvokeSomeEvent(1);
                break;
            case "FIN 2":
                MyEvents.InvokeSomeEvent(2);
                break;
            case "FIN 3":
                MyEvents.InvokeSomeEvent(3);
                break;
            case "death":
                transform.position = teleportPosition;
                GameOver.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Triangle"))
        {
            Debug.Log("reset gamddezae");
            transform.position = teleportPosition;
            GameOver.gameObject.SetActive(true);
            //TODO afficher menu game over;
        }
       // Debug.Log("Entered collision with " + collision.gameObject.name);

        isGrounded = true;
        animator.SetBool("isJumping", false);
    }

    //Hitting a collider 2D
    private void OnCollisionStay2D(Collision2D collision)
    {
      //  Debug.Log("Colliding with " + collision.gameObject.name);
        isGrounded = true;
        animator.SetBool("isJumping", false);
    }

    //Just stop hitting a collider 2D

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log("Exited collision with " + collision.gameObject.name);
        
          //  Debug.Log("is it square ??");
            isGrounded = false;
            animator.SetBool("isJumping", true);
        
    }
}
