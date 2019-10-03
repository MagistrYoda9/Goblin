using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isFacingRight = true;
    public float speed = 20;
    public float jumpForce = 3;
    private float horizontalInput;
    private SpriteRenderer playerSprite;
    private Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * speed * Time.deltaTime * horizontalInput);
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
            playerSprite.flipX = true;
        }
        else if (direction > 0)
        {
            playerSprite.flipX = false;
        }
    }

}
