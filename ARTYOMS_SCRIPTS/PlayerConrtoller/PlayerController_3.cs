using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_3 : MonoBehaviour
{
    public int HitPoint = 100;
    public float speed = 1.0f;
    public float jumpForce = 1.0f;
    public Rigidbody2D rb;
    Animator charAnimator;
    public SpriteRenderer sprite;
    bool OnGround = false;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        charAnimator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        CheckGround();
    }

    void Update()
    {
        if (Input.GetButton("Horizontal"))
        {
            PlayerMove();
        }
        if (OnGround && Input.GetButtonDown("Jump"))
        {
            PlayerJump();

        }
    }
	
	void PlayerMove()
    {
        Vector3 tempvector = Vector3.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + tempvector, speed * Time.deltaTime);
        if (tempvector.x < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        Debug.Log("INFO. Horizontal move...");
    }

    void PlayerJump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        Debug.Log("INFO. Space...");
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.02f);
        OnGround = colliders.Length > 1;
    }
}
