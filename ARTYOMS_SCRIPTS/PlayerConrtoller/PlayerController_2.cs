using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController_2 : MonoBehaviour
{
	Rigidbody2D rb;
	public float horizontalSpeed;
	public float verticalImpulse;
	public float LivePoint;
	bool isGround;
	
	// Активизация функций //
	
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate(){
		PlayerRun();
		
		if(Input.GetKeyDown(KeyCode.Space) && isGround)
			PlayerJump();
    }
	
	void Update(){
		
    }
	
	// Движение персонажа //
	
	void PlayerRun(){
		
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
		
	}
	
	void PlayerJump(){
		rb.AddForce(new Vector2(0,verticalImpulse), ForceMode2D.Impulse);
	}
	
	// Проверка коллизии //
	
	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.tag == "Ground")
			isGround = true;
		
		if(collision.gameObject.tag == "Barb_Respawn")
			LivePoint -= 25;
		
		if(LivePoint == 0)
			ReloadLevel();
	}
	
	void OnCollisionExit2D(Collision2D collision){
		if(collision.gameObject.tag == "Ground")
			isGround = false;
	}
	
	void OnTriggerEnter2D(Collider2D HitPoint){
		if(HitPoint.gameObject.tag == "HitPoint"){
			LivePoint += 25;
			Destroy(HitPoint.gameObject);
		}
	}
	
	void Flip(){
		if(Input.GetAxis("Horizontal") > 0)
			transform.localRotation = Quaternion.Euler(0,0,0);
		
		if(Input.GetAxis("Horizontal") < 0)
			transform.localRotation = Quaternion.Euler(0,180,0);
	}
	
	void ReloadLevel()
	{
		Application.LoadLevel(Application.loadedLevel); //Метод перезагрузки уровня
	}
	
	void OnGUI()
	{
		GUI.Box(new Rect(0,0,100,30), "Live: " +LivePoint);
	}
}
