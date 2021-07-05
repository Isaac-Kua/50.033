using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// this has methods callable by players
public  class CentralManager : MonoBehaviour
{
	public  static  CentralManager centralManagerInstance;
	public  GameObject gameManagerObject;
	private  GameManagerWeek5 gameManager;
	// private  GameManager gameManager;
	public  GameObject powerupManagerObject;
	private  PowerUpManager powerUpManager;
	
	void  Awake(){
		centralManagerInstance  =  this;
		// Debug.Log("central instance set");
		gameManager  =  gameManagerObject.GetComponent<GameManagerWeek5>();
		
		// gameManager  =  gameManagerObject.GetComponent<GameManager>();
		powerUpManager  =  powerupManagerObject.GetComponent<PowerUpManager>();
	}
	// Start is called before the first frame update
	public void  Start()
	{
	}

	public  void  increaseScore(){
		gameManager.increaseScore();
	}
	
	public  void  damagePlayer(){
		gameManager.damagePlayer();
	}
	
	public  void  consumePowerup(KeyCode k, GameObject g){
		powerUpManager.consumePowerup(k,g);
	}

	public  void  addPowerup(Texture t, int i, ConsumableInterface c){
		powerUpManager.addPowerup(t, i, c);
	}
	
	public void changeScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MarioWeek5", LoadSceneMode.Single);
    }


    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

}
