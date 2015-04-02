using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {


	//private GUISkin buttonSkin = "Assets/GUI Skins/ButtonSkin";

	private float sWidth;
	private float sHeight;
	private float startX;
	private float startY;
	private float width;
	private float height;

	public GUISkin buttonSkin;
	
	
	
	void Start(){
		//print ("start called");
		sWidth = Screen.width;
		sHeight = Screen.height;
		width = (float)(sWidth/2)-150;
		height = (float)(sHeight/2);

	}



	void OnGUI(){
		GUI.skin = buttonSkin;
		//if(GUI.Button(new Rect(width*2,height,100,50),"Retry")){
		//print("called");

		if(GUI.Button(new Rect(width,height - 100,300,70),"Retry")){

			Application.LoadLevel("Level1");
		}
		if(GUI.Button(new Rect(width,height,300,70),"Main Menu")){
			Application.LoadLevel("MainMenu");
		}
		if(GUI.Button(new Rect(width,height + 100,300,70),"Exit")){
			Application.Quit();
		}
	}


}
