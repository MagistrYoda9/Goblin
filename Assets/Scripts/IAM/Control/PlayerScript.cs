using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    IMovement movementScript;
    IJumpRb jumpRb;

    bool jumpRequest = false;
    public float speed = 20;
    public float jumpForce = 15;

    // Start is called before the first frame update
    void Start()
    {
        movementScript = new BasicMovement(gameObject);
        jumpRb = new BasicJump(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        movementScript.HorizontalMovement(speed, Input.GetAxis("Horizontal"));
        if (Input.GetButtonDown("Jump"))
        {
            jumpRequest = true;
        }
    }

    private void FixedUpdate()
    {
        if (jumpRequest)
        {
            jumpRb.Jump(jumpForce);
            jumpRequest = false;
        }          
    }
}
