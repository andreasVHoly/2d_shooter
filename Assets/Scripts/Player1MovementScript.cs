using UnityEngine;
using System.Collections;

public class Player1MovementScript : MonoBehaviour {

	//a vector we assign for our speed in the x,y direction
	public Vector2 speed = new Vector2(10,10);
	
	// Update is called once per frame
	void Update () {

		//we get the input on the x axis, i.e. what direction we are moving on, HorizontalP1 is set up to be for player 1
		float inputX = Input.GetAxis ("HorizontalP1");
		//we get the input on the y axis, i.e. what direction we are moving on, VerticalP1 is set up to be for player 1
		float inputY = Input.GetAxis ("VerticalP1");

		//we make a new vector for the movement of where our object should be in relation to the input, and its new position it will attain by moving with its speed
		Vector3 movement = new Vector3 (speed.x * inputX, speed.y * inputY, 0);

		//we need to change this new position with repect to delta time
		movement *= Time.deltaTime;
		//we update the objects position accordinly
		transform.Translate (movement);
		   
	}
}
