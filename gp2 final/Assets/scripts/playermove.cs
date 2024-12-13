using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermove : MonoBehaviour
{
    public Rigidbody2D myRB;
    public Transform waterCheck;
    public LayerMask waterLayer;
    public Transform groundcheck;
    public LayerMask groundLayer;
    bool grounded;
    private float horizontal;
    private float vertical;
    public float waterspeed = 12f;
    public float landspeed = 2f;
    public float jumpingforce = 5f;
    public bool isfacingRight = true;
    public enum PlayerStates{ Idle, Land, InWater}
    public PlayerStates currentState;
    
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
        myRB.velocity = new Vector2(horizontal * landspeed, myRB.velocity.y);

    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundLayer);
    }

    public bool IsInWater()
    {
        return Physics2D.OverlapCircle(waterCheck.position, 0.2f, waterLayer);
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Death"))
        {
            SceneManager.LoadScene(0);
        }
        
        if(other.gameObject.CompareTag("Death2"))
        {
            SceneManager.LoadScene(1);
        }

        if(other.gameObject.CompareTag("Win"))
        {
            SceneManager.LoadScene(2);
        }

        if(other.gameObject.CompareTag("seaweed"))
        {
            landspeed = 2f;
        }
    }
}