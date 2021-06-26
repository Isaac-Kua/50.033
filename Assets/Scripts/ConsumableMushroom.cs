using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableMushroom : MonoBehaviour
{
	private float originalX;
	private int moveRight = -1;
	private Vector2 velocity;
	private Rigidbody2D itemBody;
	private SpriteRenderer itemSprite;
	public float speed;

	void Start()
	{
		itemBody = GetComponent<Rigidbody2D>();
		// enemySprite = GetComponent<SpriteRenderer>();
		// get the starting position
		originalX = transform.position.x;
		ComputeVelocity();
		itemBody.AddForce(Vector2.up  *  20, ForceMode2D.Impulse);
	}
	void ComputeVelocity(){
		velocity = new Vector2((moveRight)*speed, 0);
	}
	void MoveItem(){
		itemBody.MovePosition(itemBody.position + velocity * Time.fixedDeltaTime);
		// enemySprite.flipX = !enemySprite.flipX;
	}
	
	void Update()
	{		
		MoveItem();
	}
	
	void  OnBecameInvisible(){
		Destroy(gameObject);	
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
      if (!col.gameObject.CompareTag("Player")) {
			moveRight *= -1;
			ComputeVelocity();
			MoveItem();
      };
	  
	  if (col.gameObject.CompareTag("Player")) {
          Debug.Log("gotcha bitch");
		  OnBecameInvisible();
      };
	}	
}
