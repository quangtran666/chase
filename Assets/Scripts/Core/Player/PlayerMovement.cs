using System;
using Unity.Netcode;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    [Header("References")] 
    [SerializeField] private InputControls inputControls;
    [SerializeField] private Rigidbody2D rb;
    
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 16f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    
    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck; 
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    
    private bool isGrounded;
    private bool isJumping;
    private bool facingRight = true;

    private void Update()
    {
        if (!IsOwner) return;

        CheckGround();

        HandleJump();
    }

    private void FixedUpdate()
    {
        if (!IsOwner) return;
        
        HandleMovement();
        
        ApplyJumpMultipliers();
    }

    private static void ApplyJumpMultipliers()
    {
        
    }

    private void HandleMovement()
    {
        var moveInput = inputControls.MoveInput.x;
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        
        switch (moveInput)
        {
            case > 0 when !facingRight:
            case < 0 when facingRight:
                Flip();
                break;
        }
    }   

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private static void HandleJump()
    {
        
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
