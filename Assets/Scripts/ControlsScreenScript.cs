using UnityEngine;
using System.Collections;

public class ControlsScreenScript : MonoBehaviour {
	

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
		GUI.Label(new Rect(sWidth/2-250,0,500, 300),"Controls");
		
	}
}
