﻿using UnityEngine;
using System.Collections;

public class Player1Movement : MonoBehaviour {

	public Vector2 speed = new Vector2(10,10);
	
	// Update is called once per frame
	void Update () {

		float inputX = Input.GetAxis ("HorizontalP1");
		float inputY = Input.GetAxis ("VerticalP1");
		
		Vector3 movement = new Vector3 (speed.x * inputX, speed.y * inputY, 0);
		
		movement *= Time.deltaTime;
		
		transform.Translate (movement);
		   
	}
}
