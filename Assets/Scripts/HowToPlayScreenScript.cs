using UnityEngine;
using System.Collections;

/**
 * this class handles the scene where the game is explained
 */
public class HowToPlayScreenScript : MonoBehaviour {

	//Note: need to be set in unity
	//custom text skin
	public GUISkin textSkin;
	//custom button skin
	public GUISkin buttonSkin;


	//some positiioning vars
	private float sWidth;
	private float sHeight;
		
	//called at start
	void Start(){
		sWidth = Screen.width;//init
		sHeight = Screen.height;//init
	}


	//called every frame
	void OnGUI(){
		//we make a back button to take us back to the main menu
		GUI.skin = buttonSkin;
		if(GUI.Button(new Rect(sWidth-100, sHeight-50, 100,50 ),"Back")){
			Application.LoadLevel("MainMenu");
		}
		// we display heading to this scene
		GUI.skin = textSkin;
		GUI.Label(new Rect(sWidth/2-400,0,800, 300),"How to play:");
		
	}
}
