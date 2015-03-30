using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public Vector2 speed = new Vector2 (10, 10);
	public Vector2 direction = new Vector2 (0,0);
	private int counter = 120;
	// Update is called once per frame
	void Update () {



		//if not chasing
		counter++;

		//if we have moved for 120ms(2s)
		if (counter > 120) {
			//we get a random number to decide our direction of movement
			int number = Random.Range (0, 3);
			//we move up
			if (number == 0) {
				direction = new Vector2(0,1);
			}
			//we move down
			else if (number == 1) {
				direction = new Vector2(0,-1);
			}
			//we move left
			else if (number == 2) {
				direction = new Vector2(1,0);
			}
			//we move right
			else if (number == 3) {
				direction = new Vector2(-1,0);
			}

			counter = 0;
		}
		// a new vector to devcide our 
		Vector3 movement = new Vector3 (speed.x * direction.x, speed.y * direction.y, 0);
		
		movement *= Time.deltaTime;
		
		transform.Translate (movement);

	}
}
