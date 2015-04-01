using UnityEngine;
using System.Collections;

public class EnemyMovementScript : MonoBehaviour {

	public Vector2 speed = new Vector2 (10, 10);
	
	public Vector2 direction = new Vector2 (0,0);

	private int counter = 120;

	public bool chasing = false;


	public float detectionRange = 50f;
	
	private GameObject player1;

	private GameObject player2;



	// Update is called once per frame
	void Update () {



		var rayCast = Physics2D.Raycast(this.transform.position, direction, detectionRange, 1 << LayerMask.NameToLayer("Player"));

		if(rayCast){
			//need to handle chasing
			//check x

			//check y
		}
		else{
			//if not in range
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

		//need to check distances
		//if true
			//check which player is closer
			//set chasing to true

		/*float distance1 = Vector3.Distance(player1.transform.position, this.gameObject.transform.position);

		//get player2's distance from our enemy
		float distance2 = Vector3.Distance(player2.transform.position, this.gameObject.transform.position);

		Vector3 direction;
		//we want to see if both playe rs are within range
		if (distance1 <= detectionRange || distance2 <= detectionRange){
			//see which player is closer
			if (distance1 < distance2){

			}
			else{

				
			}
		}*/







		//if not true
			//increment counter
			//set chasing to false
			//check counter
				//move in new direction
			//else
				//move in old direction




	}
}
