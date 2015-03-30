using UnityEngine;
using System.Collections;

public class Player2Movement : MonoBehaviour {


	public Vector2 speed = new Vector2(10,10);


	// Update is called once per frame
	void Update () {
		
		float inputX = Input.GetAxis ("HorizontalP2");
		float inputY = Input.GetAxis ("VerticalP2");
		
		Vector3 movement = new Vector3 (speed.x * inputX, speed.y * inputY, 0);
		
		movement *= Time.deltaTime;
		
		transform.Translate (movement);
	}
}
