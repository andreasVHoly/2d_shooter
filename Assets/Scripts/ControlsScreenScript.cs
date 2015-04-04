using UnityEngine;
using System.Collections;

/**
 * This class has 2 ui elements, which are easier to hard code as we use the screen width/height which changes
 * The other elements are defined as game objects in the specific 'Control' scene
 */
public class ControlsScreenScript : MonoBehaviour {
	
	//NOTE: variables below need to be assigned in unity, otherwise nullptr
	//custom skin for the text
	public GUISkin textSkin;
	//custom skin for the buttons
	public GUISkin buttonSkin;


	//set variables
	private float sWidth;
	private float sHeight;
	
	//called at start
	void Start(){
		sWidth = Screen.width;//init
		sHeight = Screen.height;//init
	}

	//called every frame
	//displays our gui items
	void OnGUI(){
		//we make a new button
		GUI.skin = buttonSkin;
		if(GUI.Button(new Rect(sWidth-100, sHeight-50, 100,50 ),"Back")){
			Application.LoadLevel("MainMenu");//if the button is pressed we go back to the main menu
		}
		//we make a new heading
		GUI.skin = textSkin;
		GUI.Label(new Rect(sWidth/2-250,0,500, 300),"Controls");
		
	}
}
