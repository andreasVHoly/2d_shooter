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
	
	
	
	void Start(){
		sWidth = Screen.width;
		sHeight = Screen.width;
		width = (float)(sWidth/5);
		height = (float)(sHeight/2);

	}



	void OnGUI(){
		//GUI.skin = buttonSkin;
		if(GUI.Button(new Rect(width*2,height,100,50),"Retry")){
			Application.LoadLevel("Level1");
		}
		if(GUI.Button(new Rect(width*4,height,100,50),"Main Menu")){
			Application.LoadLevel("MainMenu");
		}
	
	}


}
