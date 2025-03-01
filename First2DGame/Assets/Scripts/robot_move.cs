using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot_move : MonoBehaviour
{
    public float speed = 5f;
    public float jump = 2f;
    private Rigidbody2D rb;
    private bool isFacingRight = true;

    public float leftBound = -8f; 
    public float rightBound = 8f;

    public LayerMask groundLayer;
    private bool isGrounded;

    public float groundCheckDistance = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        isGrounded = Physics2D.Raycast(transform.position + Vector3.down * 0.5f, Vector2.down, groundCheckDistance, groundLayer);

        
        float speedX = Input.GetAxisRaw("Horizontal") * speed;

       
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
        }

       
        rb.linearVelocity = new Vector2(speedX, rb.linearVelocity.y);

        
        float clampedX = Mathf.Clamp(transform.position.x, leftBound, rightBound);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        
        Flip(speedX);
    }

    private void Flip(float speedX)
    {
        if ((isFacingRight && speedX < 0f) || (!isFacingRight && speedX > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
