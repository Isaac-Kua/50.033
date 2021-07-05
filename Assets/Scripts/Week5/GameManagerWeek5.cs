using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManagerWeek5 : Singleton<GameManagerWeek5>
{
	public  Text score;
	private  int playerScore =  0;
	public  delegate  void gameEvent();
	public  static  event  gameEvent OnPlayerDeath;
	public  static  event  gameEvent OnEnemyKilled;
	
	override  public  void  Awake(){
		base.Awake();
		playerScore = 0;
		Debug.Log("Score is Listening");
		GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Score");
		GameObject chosen = gameObjects[0];
		score = chosen.GetComponent<Text>();
	}
	
	public  void  increaseScore(){
		playerScore  +=  1;
		// Debug.Log("Good Job");
		Debug.Log(playerScore);
		OnEnemyKilled();
		score.text  =  "SCORE: "  +  playerScore.ToString();
	}
	
	public  void  damagePlayer(){
		playerScore = 0;	
		// Debug.Log(playerScore);
		score.text  =  "SCORE: "  +  playerScore.ToString();
		Debug.Log("Mario Died");
		OnPlayerDeath();
	}
}
