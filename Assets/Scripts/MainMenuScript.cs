using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {


	public GUISkin buttonSkin;
	public GUISkin textSkin;
	private float sWidth;
	private float sHeight;
	private float startX;
	private float startY;
	private float width;
	private float height;



	void Start(){
		sWidth = Screen.width;
		sHeight = Screen.width;
		width = (float)(sWidth/4);
		height = (float)(sHeight*0.1);
		startY = (float)(sHeight/4);
		startX = (float)(sWidth/2 - width/2);
	}

	void OnGUI(){
		GUI.skin = buttonSkin;
		if(GUI.Button(new Rect(0,startY-height/2,width-50,height),"New Game")){
			Application.LoadLevel("Level1");
		}
		if(GUI.Button(new Rect(width*1,startY-height/2,width-50,height),"How To Play")){
			Application.LoadLevel("HowToPlay");
		}
		if(GUI.Button(new Rect(width*2,startY-height/2,width-50,height),"Controls")){
			Application.LoadLevel("Controls");
		}
		if(GUI.Button(new Rect(width*3,startY-height/2,width-50,height),"Exit")){
			Application.Quit();
		}


		GUI.skin = textSkin;
		GUI.Label(new Rect(sWidth/2-550/2,50,550, 300),"Darkness");

	}
}
