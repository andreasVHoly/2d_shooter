using UnityEngine;
using System.Collections;

public class LevelLoaderScript : MonoBehaviour {

	public bool player1 = false;
	public bool player2 = false;
	public bool player1Dead =  false;
	public bool player2Dead = false;

	public GUISkin buttonSkin;

	public GameObject scripts;

	private SoundScript sound;

	void Start(){
		sound = scripts.GetComponent<SoundScript>();
	}

	void Update(){
		if ( (player1 && player2) || (player1 && player2Dead) || (player1Dead && player2)){

			Application.LoadLevel("GameWon");
		}
		if (player1Dead && player2Dead){
			//print("should be loading next level");
			sound.playGameOverSound();
			Application.LoadLevel("GameOver");
		}

	}
	
	
	public void loadNextLevel(string levelName){
		Application.LoadLevel(levelName);
	}


	void OnGUI(){
		
		GUI.skin = buttonSkin;
		if(GUI.Button(new Rect(Screen.width-100, 0, 100,50 ),"Exit")){
			Application.LoadLevel("MainMenu");
		}
	
		
	}


}
