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
		if(GUI.Button(new Rect(startX,startY,width,height),"New Game")){
			Application.LoadLevel("Level1");
		}

		GUI.skin = textSkin;
	//	GUI.Label(new Rect(sWidth - 50,sHeight - 100,100,50),"Darkness");
		GUI.Label(new Rect(sWidth/2-550/2,50,550, 300),"Darkness");

	}
}
