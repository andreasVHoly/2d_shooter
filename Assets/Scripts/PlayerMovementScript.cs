using UnityEngine;
using System.Collections;

/**
 * This class handles the movement for our player objects and the sprites based on the direction
 */
public class PlayerMovementScript : MonoBehaviour {

	//a vector we assign for our speed in the x,y direction
	public Vector2 speed = new Vector2(10,10);

	//the direction we are moving in
	public DirectionEnumScript.Direction direction;
	
	//the sprites we change on the sprite renderer based on the direction of movement
	public Sprite left;
	public Sprite right;
	public Sprite up;
	public Sprite down;

	//our sprite renderer
	private SpriteRenderer srender;

	//called on start
	void Start(){
		//default direction
		direction = DirectionEnumScript.Direction.NORTH;
		//init
		srender = this.gameObject.GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {
		float inputX = 0, inputY = 0;//default
		//if this is player 1
		if (this.gameObject.name == "Player 1") {
			//we get the input on the x axis, i.e. what direction we are moving on, HorizontalP1 is set up to be for player 1
			inputX = Input.GetAxis ("HorizontalP1");
			//we get the input on the y axis, i.e. what direction we are moving on, VerticalP1 is set up to be for player 1
			inputY = Input.GetAxis ("VerticalP1");
		}
		//if this is player 2
		else{
			//we get the input on the x axis, i.e. what direction we are moving on, HorizontalP1 is set up to be for player 1
			inputX = Input.GetAxis ("HorizontalP2");
			//we get the input on the y axis, i.e. what direction we are moving on, VerticalP1 is set up to be for player 1
			inputY = Input.GetAxis ("VerticalP2");
		}


		//if we are moving right
		if(inputX > 0 ){
			//we set our direction enum
			direction = DirectionEnumScript.Direction.EAST;
			//we change the sprite if it has not been changed already
			if(srender.sprite != right){
				srender.sprite = right;
			}
		}
		//moving left
		else if (inputX < 0){
			//we set our direction enum
			direction = DirectionEnumScript.Direction.WEST;
			//we change the sprite if it has not been changed already
			if(srender.sprite != left){
				srender.sprite = left;
			}
		}
		//moving up
		else if(inputY > 0){
			//we set our direction enum
			direction = DirectionEnumScript.Direction.NORTH;
			//we change the sprite if it has not been changed already
			if(srender.sprite != up){
				srender.sprite = up;
			}
		}
		//moving down
		else if (inputY < 0){
			//we set our direction enum
			direction = DirectionEnumScript.Direction.SOUTH;
			//we change the sprite if it has not been changed already
			if(srender.sprite != down){
				srender.sprite = down;
			}
		}


		//we make a new vector for the movement of where our object should be in relation to the input, and its new position it will attain by moving with its speed
		Vector3 movement = new Vector3 (speed.x * inputX, speed.y * inputY, 0);
		//we need to change this new position with repect to delta time
		movement *= Time.deltaTime;
		//we update the objects position accordinly
		transform.Translate (movement);
	}
}
