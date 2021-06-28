using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerWeek5 : Singleton<GameManagerWeek5>
{
	public  Text score;
	private  int playerScore =  0;
	public  delegate  void gameEvent();
	public  static  event  gameEvent OnPlayerDeath;
	public  static  event  gameEvent OnEnemyKilled;
	
	
	public  void  increaseScore(){
		playerScore  +=  1;
		score.text  =  "SCORE: "  +  playerScore.ToString();
		OnEnemyKilled();
	}
	
	public  void  damagePlayer(){
		OnPlayerDeath();
	}
	
	
	// Singleton Pattern
	private  static  GameManagerWeek5 _instance;
	// Getter
	public  static  GameManagerWeek5 Instance
	{
		get { return  _instance; }
	}
	//Member variables can be referred to as fields.  
	private  int _healthPoints; 

	//healthPoints is a basic property  
	public  int healthPoints { 
		get { 
			//Some other code  
			// ...
			return _healthPoints; 
		} 
		set { 
			// Some other code, check etc
			// ...
			_healthPoints = value; // value is the amount passed by the setter
		} 
	}

	// // usage
	// Debug.Log(player.healthPoints); // this will call instructions under get{}
	// player.healthPoints += 20;
	
	// private  void  Awake()
	// {
		// // check if the _instance is not this, means it's been set before, return
		// if (_instance  !=  null  &&  _instance  !=  this)
		// {
			// Destroy(this.gameObject);
			// return;
		// }
		
		// // otherwise, this is the first time this instance is created
		// _instance  =  this;
		// // add to preserve this object open scene loading
		// DontDestroyOnLoad(this.gameObject); // only works on root gameObjects
	// }
	
	override  public  void  Awake(){
		base.Awake();
		Debug.Log("awake called");
		// other instructions...
	}
}
