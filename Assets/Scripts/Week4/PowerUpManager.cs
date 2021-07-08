using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class PowerUpManager : MonoBehaviour
{
	public  List<GameObject> powerupIcons;
	private  List<ConsumableInterface> powerups;
	private GameObject[] gameObjects;

	// Start is called before the first frame update
	public  void  Awake(){
		// base.Awake();
		gameObjects = GameObject.FindGameObjectsWithTag("Powerup");
		powerupIcons = new List<GameObject>(gameObjects);
		powerups  =  new  List<ConsumableInterface>();
		for (int i =  0; i<powerupIcons.Count; i++){
			powerupIcons[i].GetComponent<RawImage>().enabled = false;
			Debug.Log(powerupIcons[i].name);
			powerups.Add(null);
		}
	}
	
	public  void  addPowerup(Texture texture, int index, ConsumableInterface i){
		Debug.Log("adding powerup");
		// powerupIcons = powerupIcons;
		if (index  <  powerupIcons.Count){
			powerups[index] =  i;
			powerupIcons[index].GetComponent<RawImage>().enabled = true;
			powerupIcons[index].GetComponent<RawImage>().texture = texture;
		}
	}

	public  void  removePowerup(int index){
		if (index  <  powerupIcons.Count){
			powerupIcons[index].GetComponent<RawImage>().enabled = false;
			powerups[index] =  null;
		}
	}
	
	void  cast(int i, GameObject p){
		// Debug.Log(powerups[i] !=  null);

		if (powerups[i] !=  null){
			powerups[i].consumedBy(p); // interface method
			removePowerup(i);
		}
	}

	public  void  consumePowerup(KeyCode k, GameObject player){
		switch(k){
		case  KeyCode.Z:
			cast(0, player);
			break;
		case  KeyCode.X:
			cast(1, player);
			break;
		default:
			break;
		}
	}

}