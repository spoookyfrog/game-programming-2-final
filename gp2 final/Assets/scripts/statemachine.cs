using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class statemachine : MonoBehaviour
{
    public playermove player;
    public enum PlayerStates{ Idle, Land, InWater}

    public PlayerStates currentState;

    private void Start ()
    {
        currentState = PlayerStates.Idle;
    }
    private void Update ()
    {
        switch (currentState)
        {
            case PlayerStates.Idle:
                Idle();
            if (player.IsGrounded() && Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1f)
            {
                ChangeState(PlayerStates.Land);
            }
            break;

            case PlayerStates.Land:
                Land();
            if (player.IsGrounded() && Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.1f)
            {
                ChangeState(PlayerStates.Idle);
            }
        
            else if (player.IsInWater())
            {
                ChangeState(PlayerStates.InWater);
            }
            break;

            case PlayerStates.InWater:
                InWater();

            if (!player.IsInWater() && player.IsGrounded())
            {
                ChangeState(PlayerStates.Land);
            }
            break;
        }
    }
    
private void ChangeState(PlayerStates newState)
    {
        if (currentState == newState) return; 
        currentState = newState;

        Debug.Log($"{newState}");
    }

    void Idle()
    {
        
        player.myRB.velocity = new Vector2(0, player.myRB.velocity.y);
    }

    void Land()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        player.myRB.velocity = new Vector2(horizontal * player.landspeed, player.myRB.velocity.y);

        if (Input.GetButtonDown("Jump") && player.IsGrounded())
        {
            player.myRB.velocity = new Vector2(player.myRB.velocity.x, player.jumpingforce);
        }
        
    }

    void InWater()
    {
    
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        player.myRB.gravityScale = 0f;
        player.myRB.velocity = new Vector2(horizontal * player.waterspeed, Input.GetAxis("Vertical") * player.waterspeed);
    }
    
}