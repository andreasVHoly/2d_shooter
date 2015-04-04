using UnityEngine;
using System.Collections;

public class HowToPlayScreenScript : MonoBehaviour {
	
	
	public GUISkin textSkin;
	public GUISkin buttonSkin;
	private float sWidth;
	private float sHeight;
	
	
	
	void Start(){
		sWidth = Screen.width;
		sHeight = Screen.height;
	}
	
	void OnGUI(){
		
		GUI.skin = buttonSkin;
		if(GUI.Button(new Rect(sWidth-100, sHeight-50, 100,50 ),"Back")){
			Application.LoadLevel("MainMenu");
		}
		
		GUI.skin = textSkin;
		GUI.Label(new Rect(sWidth/2-400,0,800, 300),"How to play:");
		
	}
}
