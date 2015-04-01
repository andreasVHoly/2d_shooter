using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

	//a vector we assign for our speed in the x,y direction
	public Vector2 speed = new Vector2(10,10);
	

	public DirectionEnumScript.Direction direction;

	void Start(){
		direction = DirectionEnumScript.Direction.NORTH;
	}

	// Update is called once per frame
	void Update () {

		float inputX = 0, inputY = 0;

		if (this.gameObject.name == "Player 1") {
			//we get the input on the x axis, i.e. what direction we are moving on, HorizontalP1 is set up to be for player 1
			inputX = Input.GetAxis ("HorizontalP1");
			//we get the input on the y axis, i.e. what direction we are moving on, VerticalP1 is set up to be for player 1
			inputY = Input.GetAxis ("VerticalP1");
		}
		//shooting key for player 1
		else if (this.gameObject.name == "Player 2") {
			//we get the input on the x axis, i.e. what direction we are moving on, HorizontalP1 is set up to be for player 1
			inputX = Input.GetAxis ("HorizontalP2");
			//we get the input on the y axis, i.e. what direction we are moving on, VerticalP1 is set up to be for player 1
			inputY = Input.GetAxis ("VerticalP2");
		}

		if(inputX > 0){
			//print("direction changed to east");
			//transform.Rotate(new Vector3(0,0,-90));
			direction = DirectionEnumScript.Direction.EAST;
		}
		else if (inputX < 0){
			//print("direction changed to west");
			//transform.Rotate(new Vector3(0,0,90));
			direction = DirectionEnumScript.Direction.WEST;
		}
		else if(inputY > 0){
			//print("direction changed to north");
			direction = DirectionEnumScript.Direction.NORTH;
		}
		else if (inputY < 0){
			//print("direction changed to south");
			//transform.Rotate(new Vector3(0,0,180));
			//transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
			direction = DirectionEnumScript.Direction.SOUTH;
		}

		//we make a new vector for the movement of where our object should be in relation to the input, and its new position it will attain by moving with its speed
		Vector3 movement = new Vector3 (speed.x * inputX, speed.y * inputY, 0);

		//we need to change this new position with repect to delta time
		movement *= Time.deltaTime;
		//we update the objects position accordinly
		transform.Translate (movement);
		   
	}
}
