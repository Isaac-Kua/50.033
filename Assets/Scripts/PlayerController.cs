using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController: MonoBehaviour
{
	public float speed;
	public float upSpeed = 10;
	public float maxSpeed = 10;
	public Transform enemyLocation;
	public Text scoreText;
	
	private Rigidbody2D marioBody;
	private SpriteRenderer marioSprite;
	// private Animator marioAnimator;
	// private AudioSource marioAudio;
	private bool onGroundState = true;
	private bool faceRightState = true;
	private bool countScoreState = false;
	private float score = 0;
	private float positionY = -3.5f;
	
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate =  30;
		marioBody = GetComponent<Rigidbody2D>();
		marioSprite = GetComponent<SpriteRenderer>();
		// marioAnimator = GetComponent<Animator>();
		// marioAudio = GetComponent<AudioSource>();
    }

	void  FixedUpdate()
	{
		
		if (Input.GetKeyUp("a") || Input.GetKeyUp("d")){
			// stop
			marioBody.velocity = Vector2.zero;
		 }
		  
		
		float moveHorizontal = Input.GetAxis("Horizontal");
		if (Mathf.Abs(moveHorizontal) > 0){
			Vector2 movement = new Vector2(moveHorizontal, 0);
			if (marioBody.velocity.magnitude < maxSpeed)
                  marioBody.AddForce(movement * speed);
		}
	  
		if (Input.GetKeyDown("space") && onGroundState)
		{
			marioBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
			onGroundState = false;
			countScoreState = true; //check if Gomba is underneath
		}
	}
	
	// called when the cube hits the floor
	void OnCollisionEnter2D(Collision2D col)
	{
      if (col.gameObject.CompareTag("Ground")) {
          onGroundState = true; // back on ground
          countScoreState = false; // reset score state
          scoreText.text = "Score: " + score.ToString();
      };
	  
	}	
	
	// Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown("a") && faceRightState){
			faceRightState = false;
			marioSprite.flipX = true;
			// if (Mathf.Abs(marioBody.velocity.x)>1.0) marioAnimator.SetTrigger("onSkid");
		}

		if (Input.GetKeyDown("d") && !faceRightState){
			faceRightState = true;
			marioSprite.flipX = false;
			// if (Mathf.Abs(marioBody.velocity.x)>1.0) marioAnimator.SetTrigger("onSkid");
		}   
		
		if (!onGroundState && countScoreState)
      {
          if (Mathf.Abs(transform.position.x - enemyLocation.position.x) < 0.5f)
          {
              countScoreState = false;
              score++;
			  enemyLocation.localScale = new Vector3(1+score/10,1+score/10,0);
			  enemyLocation.position = new Vector3(enemyLocation.position.x,positionY+score/20,0);
              Debug.Log(score);
          }
      }
	  
	  // marioAnimator.SetFloat("xSpeed",Mathf.Abs(marioBody.velocity.x));
	  // marioAnimator.SetBool("onGround",onGroundState);
    }
	
	void OnTriggerEnter2D(Collider2D other)
  {
      if (other.gameObject.CompareTag("Enemy"))
      {
          Debug.Log("Collided with Gomba!");
		  Application.LoadLevel(0);
      }
  }
  
  // void PlayJumpSound(){
	  // marioAudio.PlayOneShot(marioAudio.clip);
  // }
}
