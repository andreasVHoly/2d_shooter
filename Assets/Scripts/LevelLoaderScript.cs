using UnityEngine;
using System.Collections;

public class LevelLoaderScript : MonoBehaviour {

	public bool player1 = false;
	public bool player2 = false;
	public bool player1Dead =  false;
	public bool player2Dead = false;

	public GameObject scripts;



	void Update(){
		if ( (player1 && player2) || (player1 && player2Dead) || (player1Dead && player2)){
			//loadNextLevel ("Level2");
			Application.LoadLevel("MainMenu");
		}
		if (player1Dead && player2Dead){
			//print("should be loading next level");
			player1Dead = true;
			player2Dead = true;
			scripts.GetComponent<GameOverScript>().enabled = true;
		}

	}
	
	
	public void loadNextLevel(string levelName){
		Application.LoadLevel(levelName);
	}



}
