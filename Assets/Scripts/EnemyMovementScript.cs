using UnityEngine;
using System.Collections;

public class EnemyMovementScript : MonoBehaviour {

	public Vector2 speed = new Vector2 (10, 10);
	
	public Vector2 direction = new Vector2 (0,0);

	private int counter = 120;

	public bool chasing = false;


	public float detectionRange = 50f;
	public float chasingRange = 70f;
	
	private GameObject player1;

	private GameObject player2;

	private GameObject prey;



	// Update is called once per frame
	void Update () {


		var rayCast = Physics2D.Raycast(this.transform.position, direction, detectionRange, 1 << LayerMask.NameToLayer("Player"));
		Debug.DrawRay(transform.position, new Vector3(direction.x,direction.y,0), Color.red);
		var gap = Vector3.Distance(this.transform.position, prey.transform.position);

		if (chasing && gap < chasingRange){
			print("chasing");
			Vector3 target = prey.transform.position;
			Vector3 hunter = this.transform.position;

			//check x
			if (hunter.x < target.x ){
				//move right
				direction.x = 1;
				//print("hunter right");
			}
			else if (hunter.x > target.x){
				//move left
				direction.x  = -1;
				//print("hunter left");
				
			}
			else{
				//stay still
				direction.x = 0;	
				//print("hunter stay x");
				
			}

			//check y
			if (hunter.y < target.y ){
				//move up
				direction.y = 1;
				//print("hunter up");
				
			}
			else if (hunter.y > target.y){
				//move down
				direction.y = -1;
				//print("hunter down");
				
			}
			else{
				//stay still
				direction.y = 0;
				//print("hunter stay y");
				
			}
		}
		else if(rayCast){
			prey = rayCast.transform.gameObject;
			chasing = true;
			print("raycasting");
		}
		else{
			//if not in range
			print("chilling");

			counter++;
			chasing = false;
			//if we have moved for 120ms(2s)
			if (counter > 120) {
				//we get a random number to decide our direction of movement
				int number = Random.Range (0, 3);
				//we move up
				switch(number){
					//we move up
					case 0:
						direction = new Vector2(0,1);
						break;
					//we move down
					case 1:
						direction = new Vector2(0,-1);
						break;
					//we move left
					case 2:
						direction = new Vector2(1,0);
						break;
					//we move right
					case  3:
						direction = new Vector2(-1,0);
						break;
					default:
						direction = new Vector2(0,1);
						break;

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
