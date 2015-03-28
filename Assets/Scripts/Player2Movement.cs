using UnityEngine;
using System.Collections;

public class Player2Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("UPARROW")){
			//we need to move up
		}
		
		if (Input.GetButtonDown("DOWNARROW")) {
			//we need to move down
		}
		
		if (Input.GetButtonDown("RIGHTARROW")) {
			//we need to move right
		}
		
		if (Input.GetButtonDown("LEFTARROW")){
			//we need to move left
		}
	}
}
