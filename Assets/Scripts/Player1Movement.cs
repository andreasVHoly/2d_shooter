using UnityEngine;
using System.Collections;

public class Player1Movement : MonoBehaviour {

	public Vector2 speed = new Vector2(20,20);
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("W")) {
			//we need to move up
		}
		
		if (Input.GetButtonDown("S")) {
			//we need to move down
		}

		if (Input.GetButtonDown("D")) {
			//we need to move right
		}

		if (Input.GetButtonDown("A")) {
			//we need to move left
		}


		

	}
}
