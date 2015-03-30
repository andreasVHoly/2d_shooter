using UnityEngine;
using System.Collections;

public class SingleDirMovementScript : MonoBehaviour {

	//the direction we want to move in
	//need to change x,y to get desired effect
	public Vector3 direction = new Vector3(-1,0,0);
	//the speed at which the object should move in either direction
	public Vector2 speed = new Vector2 (10, 10);
	
	// Update is called once per frame
	void Update () {
		Vector3 movement = new Vector3 (speed.x * direction.x, speed.y * direction.y, 0);
		
		movement *= Time.deltaTime;
		
		transform.Translate (movement);
	}
}
