using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	private float originalX;
	private float maxOffset = 5.0f;
	private float enemyPatroltime = 2.0f;
	private int moveRight = -1;
	private Vector2 velocity;
	private Rigidbody2D enemyBody;
	private SpriteRenderer enemySprite;

	void Start()
	{
		enemyBody = GetComponent<Rigidbody2D>();
		enemySprite = GetComponent<SpriteRenderer>();
		// get the starting position
		originalX = transform.position.x;
		ComputeVelocity();
	}
	void ComputeVelocity(){
		velocity = new Vector2((moveRight)*maxOffset / enemyPatroltime, 0);
	}
	void MoveGomba(){
		enemyBody.MovePosition(enemyBody.position + velocity * Time.fixedDeltaTime);
		// enemySprite.flipX = !enemySprite.flipX;
	}
	
	void Update()
	{		
		if (Mathf.Abs(enemyBody.position.x - originalX) < maxOffset)
		{// move gomba
			MoveGomba();
		}
		else{
			// change direction
			enemySprite.flipX = !enemySprite.flipX;
			moveRight *= -1;
			ComputeVelocity();
			MoveGomba();
		}
	}
}
