using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerEV : MonoBehaviour
{
    private float force;
    public IntVariable marioUpSpeed;
    public IntVariable marioMaxSpeed;
    public GameConstants gameConstants;
	  
	private Rigidbody2D marioBody;
	private SpriteRenderer marioSprite;
	private Animator marioAnimator;
	private AudioSource marioAudio;
	private bool onGroundState = true;
	private bool faceRightState = true;
	private bool countScoreState = false;
	
	private bool isDead;
	private bool isADKeyUp = true;
	private bool isSpacebarUp;
	
	void Start()
	{
		// Application.targetFrameRate =  30;
		marioBody = GetComponent<Rigidbody2D>();
		marioSprite = GetComponent<SpriteRenderer>();
		marioAnimator = GetComponent<Animator>();
		marioAudio = GetComponent<AudioSource>();
		 
		marioUpSpeed.SetValue(gameConstants.playerMaxJumpSpeed);
        marioMaxSpeed.SetValue(gameConstants.playerMaxSpeed);
        force = gameConstants.playerDefaultForce;
		// GameManager.OnPlayerDeath  +=  PlayerDiesSequence;
	}
	
	void Update(){
		if (Input.GetKeyDown("d")){
			isADKeyUp = false;
			faceRightState = true;
		}
		
		if (Input.GetKeyUp("d")){
			isADKeyUp = true;
		}
		
		if (Input.GetKeyDown("a")){
			isADKeyUp = false;
			faceRightState = false;
		}
		
		if (Input.GetKeyUp("a")){
			isADKeyUp = true;
		}
		
		if (Input.GetKeyDown("space")){
			isSpacebarUp = false;
		}
		
		if (Input.GetKeyUp("space")){
			isSpacebarDown = true;
		}
		
		marioSprite.flipX = !faceRightState;
		marioAnimator.SetFloat("xSpeed",Mathf.Abs(marioBody.velocity.x));
		marioAnimator.SetBool("onGround",onGroundState);
		
	}
	
	void FixedUpdate()
    {
        if (!isDead)
        {
            //check if a or d is pressed currently
            if (!isADKeyUp)
            {
                float direction = faceRightState ? 1.0f : -1.0f;
                Vector2 movement = new Vector2(force * direction, 0);
                if (marioBody.velocity.magnitude < marioMaxSpeed.Value)
                    marioBody.AddForce(movement);
            }

            if (!isSpacebarUp && onGroundState)
            {
                marioBody.AddForce(Vector2.up * marioUpSpeed.Value, ForceMode2D.Impulse);
                onGroundState = false;
                // part 2
                marioAnimator.SetBool("onGround", onGroundState);
                countScoreState = true; //check if Gomba is underneath
            }
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("Ground")) {
			onGroundState = true; // back on ground
			countScoreState = false; // reset score state
			// scoreText.text = "Score: " + score.ToString();
			// dustcloud.Play();
		};
		
		if (col.gameObject.CompareTag("Obstacle")) {
			onGroundState = true; // back on ground
			// countScoreState = false; // reset score state
			// scoreText.text = "Score: " + score.ToString();
		};
	}	
	
	void PlayJumpSound(){
		marioAudio.PlayOneShot(marioAudio.clip);
	}
}