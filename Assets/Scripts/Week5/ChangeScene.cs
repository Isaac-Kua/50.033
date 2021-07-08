using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class ChangeScene : MonoBehaviour
{
	public  AudioSource changeSceneSound;
	void  OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag  ==  "Player")
		{
			changeSceneSound.PlayOneShot(changeSceneSound.clip);
			StartCoroutine(LoadYourAsyncScene("MarioWeek5"));
		}
	}

	IEnumerator  LoadYourAsyncScene(string sceneName)
	{
		yield  return  new  WaitUntil(() =>  !changeSceneSound.isPlaying);
		Debug.Log("music stopped");
		GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
		player.transform.position = new Vector3 (-6.2f,4,0);
		CentralManager.centralManagerInstance.changeScene();
	}
}
