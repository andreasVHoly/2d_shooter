using UnityEngine;
using System.Collections;

/**
 * This class managed movement in a single direction 
 * It is used for bullets to shoot them in one direction
 */
public class SingleDirMovementScript : MonoBehaviour {

	//the direction we want to move in
	//need to change x,y to get desired effect
	public Vector3 direction = new Vector3(-1,0,0);
	//the speed at which the object should move in either direction
	public Vector2 speed = new Vector2 (10, 10);



	// Update is called once per frame
	void Update () {

		//we make a new vector for the movement of where our object should be in relation to the input, and its new position it will attain by moving with its speed
		Vector3 movement = new Vector3 (speed.x * direction.x, speed.y * direction.y, 0);
		//we need to change this new position with repect to delta time
		movement *= Time.deltaTime;
		//we update the objects position accordinly
		transform.Translate (movement);
	}

	//if we want to set the direction based on a direction enum
	public void setDirection(DirectionEnumScript.Direction dir){
		//goinf up/north
		if (dir == DirectionEnumScript.Direction.NORTH){
			transform.Rotate(new Vector3(0,0,-90));
			//needs to be set to opposite direction as we are rotating above
			direction = new Vector3(-1,0,0);

		}
		//going down/south
		else if (dir == DirectionEnumScript.Direction.SOUTH){
			transform.Rotate(new Vector3(0,0,90));
			//needs to be set to opposite direction as we are rotating above, 
			direction = new Vector3(-1,0,0);
		}
		//going right/east
		else if (dir == DirectionEnumScript.Direction.EAST){
			//we flip the sprite over the x axis
			transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			direction = new Vector3(1,0,0);
		}
		//going left/west
		else{
			direction = new Vector3(-1,0,0);
		}
	}


}
