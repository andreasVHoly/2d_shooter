using UnityEngine;
using System.Collections;

public class GameOverScreenScript : MonoBehaviour {
	
	
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
		if(GUI.Button(new Rect(startX,startY-180,width,height),"Retry")){
			Application.LoadLevel("Level1");
		}
		if(GUI.Button(new Rect(startX,startY-20,width,height),"Main Menu")){
			Application.LoadLevel("MainMenu");
		}
		if(GUI.Button(new Rect(startX,startY+130,width,height),"Exit")){
			Application.Quit();
		}
		
		
		GUI.skin = textSkin;
		GUI.Label(new Rect(sWidth/2-800/2,30,800, 300),"Game Over!");
		
	}
}
