﻿using UnityEngine;
using System.Collections;

/**
 * This script handles the scene that appears when we have won the game
 */
public class GameWonScreenScript : MonoBehaviour {

	//some vars that help us position elements
	private float sWidth;
	private float sHeight;
	private float startX;
	private float startY;
	private float width;
	private float height;


	//NOTE: these vars need to be set in unity
	public GUISkin buttonSkin;
	public GUISkin textSkin;

	
	
	//called on start
	void Start(){
		sWidth = Screen.width;
		sHeight = Screen.width;
		width = (float)(sWidth/4);
		height = (float)(sHeight*0.1);
		startY = (float)(sHeight/4)-100;
		startX = (float)(sWidth/2 - width/2);
	}
	
	void OnGUI(){
		//we make 3 buttons
		GUI.skin = buttonSkin;
		if(GUI.Button(new Rect(startX-width-20,startY,width,height),"Replay")){//if we want to replay the level

			Application.LoadLevel("Level1");//load the same level

		}

		if(GUI.Button(new Rect(startX,startY,width,height),"Main Menu")){//if we want to go to the main menu
			Application.LoadLevel("MainMenu");//load the main menu scene
		}
		if(GUI.Button(new Rect(startX + width+20,startY,width,height),"Exit")){//if we want to exit
			Application.Quit();//exit the app
		}


			
			


		
		//display the heading and the kill count from the round just played
		GUI.skin = textSkin;
		GUI.Label(new Rect(sWidth/2-700/2,30,700, 300),"Well Done!");
		GUI.Label(new Rect(sWidth/2-800/2,400,800, 300),"Kill Count: " + PlayerPrefs.GetInt("Score"));
	}
}
