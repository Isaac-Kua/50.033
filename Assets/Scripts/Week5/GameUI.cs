using UnityEngine;

public  class GameUI : Singleton<GameUI>
{
	override  public  void  Awake(){
		base.Awake();
		// Time.timeScale = 0.0f;
		// Debug.Log("awake GameUI called");
		// other instructions...
	}
	
	void Start(){
		Time.timeScale = 0.0f;
	}
	
		public void StartButtonClicked()
	{
		foreach (Transform eachChild in transform)
		{
			if (eachChild.name != "Score" && eachChild.name != "Powerups")
			{
				// Debug.Log("Child found. Name: " + eachChild.name);
				// disable them
				eachChild.gameObject.SetActive(false);
				Time.timeScale = 1.0f;
          }
      }
	}
}