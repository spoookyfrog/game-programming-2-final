using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
   public Rigidbody2D myRB;
    public Transform groundcheck;
    public LayerMask groundLayer;
    private float horizontal;
    public float speed = 2f;
    public float jumpingforce = 5f;
    public bool isfacingRight = true;
    
    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            myRB.velocity = new Vector2(myRB.velocity.x, jumpingforce);
        }

        if (Input.GetButtonDown("Jump") && myRB.velocity.y > 0f)
        {
            myRB.velocity = new Vector2(myRB.velocity.x,myRB.velocity.y * 0.5f);
        }
        Flip();
    }

    void FixedUpdate()
    {
        myRB.velocity = new Vector2(horizontal * speed, myRB.velocity.y);
    }

public bool IsGrounded()
{
    return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundLayer);
}
void Flip()
    {
        if (isfacingRight && horizontal < 0f || !isfacingRight && horizontal >0f)
        {
            isfacingRight = !isfacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}