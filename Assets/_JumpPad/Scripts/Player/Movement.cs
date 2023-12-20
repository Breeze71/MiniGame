using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Component")]
    public Rigidbody2D rb;
    
    [Header("Move")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float moveLerp = 10f;

    [Header("Jump")]
    [SerializeField] private float jumpPadVelocity = 20f;
    [SerializeField] private float jumpPadSpeedMax = 15f;
    [SerializeField] private float fallMutiplier = 8;
    [SerializeField] private float jumpMutiplier = 6;

    private void Update() 
    {
        Move();
    }
    private void FixedUpdate() 
    {
        BetterJump();
        SpeedLimit();    
    }

    private void Move()
    {
        Vector2 _inputDirection = InputManager.Instance.GetPlayerMoveInput();

        rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(_inputDirection.x * moveSpeed
            , rb.velocity.y), moveLerp * Time.deltaTime);       
    }

    #region Jump
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * jumpPadVelocity;
    }
    private void SpeedLimit()
    {
        if(Mathf.Abs(rb.velocity.y) > jumpPadSpeedMax)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPadSpeedMax);
        }
    }
    private void BetterJump()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMutiplier - 1) * Time.deltaTime;
        }
        else if(rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (jumpMutiplier - 1) * Time.deltaTime;
        }
    }
    #endregion
}
