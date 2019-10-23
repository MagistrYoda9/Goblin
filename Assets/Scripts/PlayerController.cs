using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isOnGound = true;
    public float speed = 20;
    public float jumpForce = 3;
    private float horizontalInput;
    private SpriteRenderer playerSprite;
    private Rigidbody2D playerRb;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal") * speed;
        transform.Translate(Vector2.right * Time.deltaTime * (int)horizontalInput);
        playerDirection(horizontalInput);
        if (Input.GetButtonDown("Jump"))
        {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        

    }

    private void playerDirection(float direction)
    {


        if (direction < 0)
        {
            playerAnim.SetBool("isRunning", true);
            playerSprite.flipX = true;
        }
        else if (direction > 0)
        {
            playerAnim.SetBool("isRunning", true);
            playerSprite.flipX = false;
        }
        else
        {
            playerAnim.SetBool("isRunning", false);
        }
    }

}
