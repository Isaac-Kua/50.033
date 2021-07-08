using System.Collections;
using UnityEngine;

public  class OrangeMushroom : Singleton<OrangeMushroom>, ConsumableInterface
{
	private float originalX;
	private int moveRight = -1;
	private Vector2 velocity;
	private Rigidbody2D itemBody;
	private SpriteRenderer itemSprite;
	public float speed;
	public  Texture t;
	
	void Start()
	{
		itemBody = GetComponent<Rigidbody2D>();
		itemSprite = GetComponent<SpriteRenderer>();
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
		  itemBody.constraints = RigidbodyConstraints2D.FreezeAll;
		  CentralManager.centralManagerInstance.addPowerup(t, 1, this);
		  GetComponent<Collider2D>().enabled = false;
		  StartCoroutine(onCollect());
		  // Destroy(this.gameObject);
      };
	}	
	
	IEnumerator onCollect()
	{
		transform.localScale = new Vector3(3,3,3);
		yield  return  new  WaitForSeconds(0.5f);
		transform.localScale = new Vector3(0,0,0);
		
	}
	
	public  void  consumedBy(GameObject player){
		// give player jump boost
		player.GetComponent<PlayerController>().maxSpeed *=  2;
		StartCoroutine(removeEffect(player));
	}

	IEnumerator  removeEffect(GameObject player){
		Debug.Log("Starttimer Run");
		yield  return  new  WaitForSeconds(5.0f);
		player.GetComponent<PlayerController>().maxSpeed  /= 2;
		Debug.Log("run gone");
	}
}
