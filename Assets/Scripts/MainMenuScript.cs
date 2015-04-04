using UnityEngine;
using System.Collections;


/**
 * This class handles the UI elements for our main menu scene 
 */
public class MainMenuScript : MonoBehaviour {

	//NOTE: variables below need to be assigned in unity, otherwise nullptr
	//custom button skin
	public GUISkin buttonSkin;
	//custom text skin
	public GUISkin textSkin;


	//set variables, that are used to position our elements
	private float sWidth;
	private float sHeight;
	private float startY;
	private float width;
	private float height;


	//called on start
	void Start(){
		sWidth = Screen.width;//init
		sHeight = Screen.width;//init
		width = (float)(sWidth/4);//init
		height = (float)(sHeight*0.1);//init
		startY = (float)(sHeight/4);//init
	}

	//called every frame
	void OnGUI(){
		//we make 4 buttons that lead the player to the desired next scene
		GUI.skin = buttonSkin;
		if(GUI.Button(new Rect(10,startY-height/2,width-50,height),"New Game")){//we start the game
			Application.LoadLevel("Level1");
		}
		if(GUI.Button(new Rect(width*1,startY-height/2,width-50,height),"How To Play")){//we show the player how to play the game with some insructions
			Application.LoadLevel("HowToPlay");
		}
		if(GUI.Button(new Rect(width*2,startY-height/2,width-50,height),"Controls")){//we shot the controls for each player
			Application.LoadLevel("Controls");
		}
		if(GUI.Button(new Rect(width*3,startY-height/2,width-50,height),"Exit")){//we exit the application
			Application.Quit();
		}

		//we make a heading
		GUI.skin = textSkin;
		GUI.Label(new Rect(sWidth/2-550/2,50,550, 300),"Darkness");

	}
}
