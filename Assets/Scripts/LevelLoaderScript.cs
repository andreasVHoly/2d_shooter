using UnityEngine;
using System.Collections;

/**
 * This class handles loading levels and handles the state the players are in during the game
 * The players can either be playing, meaning they are plying the game and have not died or reached the beacon
 * Alternatively a player can have reached the beacon and is then marked as 'ready' with a boolean value
 * Alternatively a player is marked as dead so that the game can progress if the other player is alive
 * In this class we keep track of the states for each player and we progress the game based on these states
 */
public class LevelLoaderScript : MonoBehaviour {

	//player states
	//if player 1 is ready
	public bool player1 = false;
	//if player 2 is ready
	public bool player2 = false;
	//if player 1 is dead
	public bool player1Dead =  false;
	//if player 2 is dead
	public bool player2Dead = false;

	//Other vars that need to be assigned in Unity, otherwise will end up in Null pointers NOTE NOTE NOTE

	// custom skin to display a exit button in game to exit the game while playing
	public GUISkin buttonSkin;

	//called every frame, checks on the state of the game 
	void Update(){
		//we check if the game has been won
		if ( (player1 && player2) //if both players are ready
		    || (player1 && player2Dead) //if player 1 is ready and player 2 has died
		    || (player1Dead && player2)){//if player 2 is ready and player 1 has died

			//we load the game won scene
			//alternatively if we had another level, we would load this level here 
			Application.LoadLevel("GameWon");
		}

		//we check if the game has been lost
		if (player1Dead && player2Dead){//if both players are dead
			Application.LoadLevel("GameOver");//load the game over scene
		}
	}

	//on gui method, which diplays our exit button
	void OnGUI(){
		//we set our custom skin
		GUI.skin = buttonSkin;
		//we create a new button and check for click events
		if(GUI.Button(new Rect(Screen.width-100, 0, 100,50 ),"Exit")){
			//if the exit button is clicked we want to go to the main menu
			Application.LoadLevel("MainMenu");
		}		
	}

}
