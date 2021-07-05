using System.Collections;
using UnityEngine;

public  class RedMushroom : MonoBehaviour, ConsumableInterface
{
	void Start() {}
	
	public  Texture t;
	public  void  consumedBy(GameObject player){
		// give player jump boost
		player.GetComponent<PlayerController>().upSpeed  +=  10;
		StartCoroutine(removeEffect(player));
	}

	IEnumerator  removeEffect(GameObject player){
		yield  return  new  WaitForSeconds(5.0f);
		Destroy(gameObject);
		player.GetComponent<PlayerController>().upSpeed  -=  10;
		Debug.Log("jump gone");
	}
	
	void  OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("Player")){
			// update UI
			CentralManager.centralManagerInstance.addPowerup(t, 0, this);
		}; 
	}
}
