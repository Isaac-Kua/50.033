using System.Collections;
using UnityEngine;

public  class RedMushroom : Singleton<RedMushroom>, ConsumableInterface
{
	private float originalX;
	private int moveRight = -1;
	private Vector2 velocity;
	private Rigidbody2D itemBody;
	private SpriteRenderer itemSprite;
	public float speed;
	public  Texture t;
	private bool gotme = false;
	private GameObject follow;
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
		if (gotme){
			transform.position = follow.transform.position;
		}
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
		  CentralManager.centralManagerInstance.addPowerup(t, 0, this);
		  GetComponent<Collider2D>().enabled = false;
		  StartCoroutine(onCollect());
		  gotme = true;
		  follow = col.gameObject;
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
		player.GetComponent<PlayerController>().upSpeed  +=  10;
		StartCoroutine(removeEffect(player));
	}

	IEnumerator  removeEffect(GameObject player){
		Debug.Log("Starttimer Jump");
		yield  return  new  WaitForSeconds(5.0f);
		
		Debug.Log("expiry");
		player.GetComponent<PlayerController>().upSpeed  -=  10;
		Debug.Log("jump gone");
	}
}
