using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	void Awake(){
		for (int j =  0; j  <  2; j++)
			spawnFromPooler(ObjectType.gombaEnemy);
	}
	
    // Start is called before the first frame update
    void Start()
    {
		Debug.Log("Spawn Manager + spawn new");
        GameManagerWeek5.OnEnemyKilled +=  spawnNew;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void spawnNew(){
		spawnFromPooler(ObjectType.greenEnemy);
	}
	
	void  spawnFromPooler(ObjectType i){
		// static method access
		GameObject item =  ObjectPooler.SharedInstance.GetPooledObject(i);
		if (item  !=  null){
			//set position, and other necessary states
			item.transform.position  =  new  Vector3(Random.Range(-4.5f, 4.5f), item.transform.position.y, 0);
			item.SetActive(true);
		}
		else{
			Debug.Log("not enough items in the pool.");
		}
	}
}
