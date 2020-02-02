using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    IMovement movementScript;
    IJumpRb jumpRb;
    IAnimations animations;
    Animator animator;
    private SpriteRenderer playerSprite;
    float horizontalInput;
    bool isGrounded = true;


    bool jumpRequest = false;
    public float speed = 20;
    public float jumpForce = 15;

    // Start is called before the first frame update
    void Start()
    {
        movementScript = new BasicMovement(gameObject);
        jumpRb = new BasicJump(gameObject);
        animations = new BasicAnimations(gameObject);
        animator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            movementScript.HorizontalMovement(speed, horizontalInput);
            animations.MovementAnimation("isRunning", true, horizontalInput);
        }
        else
        {
            animations.MovementAnimation("isRunning", false, horizontalInput);
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpRequest = true;
            isGrounded = false;
        }
    }

    private void OnCollisionStay2D()
    {
        isGrounded = true;
    }

    private void FixedUpdate()
    {
        if (jumpRequest && isGrounded)
        {
            jumpRb.Jump(jumpForce);
            jumpRequest = false;
        }          
    }
}
