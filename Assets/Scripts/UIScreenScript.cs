using UnityEngine;
using System.Collections;

/**
 * This class has 2 ui elements, which are easier to hard code as we use the screen width/height which changes
 * The other elements are defined as game objects in the specific 'UI' scene
 */
public class UIScreenScript : MonoBehaviour {
	
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
		//we make a new back button
		GUI.skin = buttonSkin;
		if(GUI.Button(new Rect(sWidth-100, sHeight-50, 100,50 ),"Back")){
			Application.LoadLevel("HowToPlay");//if the button is pressed we go back to the how to play screen
		}
		//we make a new heading
		GUI.skin = textSkin;
		GUI.Label(new Rect(sWidth/2-450,0,900, 300),"User Interface");
		
	}
}
