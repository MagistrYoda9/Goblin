using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController_1 : MonoBehaviour
{
	public float horizontalSpeed;
	float speedX;
	public float verticalImpulse;
	bool isGrounded;
	public float LivePoint;
	Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        RunPlayer();
    }
	
	void RunPlayer()
	{
		if(Input.GetKey(KeyCode.D) && Input.GetAxis("Horizontal") > 0)
		{
			Flip();
			rb.velocity = new Vector2(Input.GetAxis("Horizontal") * horizontalSpeed, rb.velocity.y);
		}
		else if(Input.GetKey(KeyCode.A) && Input.GetAxis("Horizontal") < 0)
		{
			Flip();
			rb.velocity = new Vector2(Input.GetAxis("Horizontal") * horizontalSpeed, rb.velocity.y);
		}
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			JumpPlayer();
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ground")
			isGrounded = true;
		
		
		if(collision.gameObject.tag == "Barb_Respawn") //Проверка на столкновение
		{
			LivePoint -= 25;
		}
		
		if(LivePoint == 0)
			ReloadLevel();
		
		
	}
	
	private void OnCollisionExit2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ground")
			isGrounded = false;
	}
	
	void OnTriggerEnter2D(Collider2D HitPoint)
	{
		if(HitPoint.gameObject.tag == "HitPoint")
		{
			LivePoint += 25;
			Destroy(HitPoint.gameObject);
		}
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(0,0,100,30), "Live: " +LivePoint);
	}
	
	void JumpPlayer()
	{
		rb.AddForce(new Vector2(0,verticalImpulse), ForceMode2D.Impulse);
	}
	
	void ReloadLevel()
	{
		Application.LoadLevel(Application.loadedLevel); //Метод перезагрузки уровня
	}
	
	void Flip(){
		if(Input.GetAxis("Horizontal") > 0)
			transform.localRotation = Quaternion.Euler(0,0,0);
		
		if(Input.GetAxis("Horizontal") < 0)
			transform.localRotation = Quaternion.Euler(0,180,0);
	}
}
