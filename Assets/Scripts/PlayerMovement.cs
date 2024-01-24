using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalInput;
    float verticalInput;
    float moveSpeed = 5f;
    bool isFacingRight = false;
    float jumpPower = 5f;
    bool isGrounded = false;
    float distToGround;

    Rigidbody2D rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        distToGround = 0.1f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
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


    void OnTriggerEnter2D(Collider2D collision)
    {
        
            Debug.Log("reset game");
        
        
        isGrounded = true;
        animator.SetBool("isJumping", false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Triangle"))
        {
            Debug.Log("reset game");
            //TODO afficher menu game over et recommencer;
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
