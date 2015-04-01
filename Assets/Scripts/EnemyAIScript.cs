using UnityEngine;
using System.Collections;

public class EnemyAIScript : MonoBehaviour {

	public float detectionRange = 50f;

	public GameObject player1;
	public GameObject player2;
	public EnemyMovementScript enemy;


	// Use this for initialization
	void Start () {
		enemy = gameObject.GetComponent<EnemyMovementScript>();
	}
	
	// Update is called once per frame
	void Update () {
		//get player1's distance from our enemy
		float distance1 = Vector3.Distance(player1.transform.position, this.gameObject.transform.position);
		//print(distance1);
		//get player2's distance from our enemy
		float distance2 = Vector3.Distance(player2.transform.position, this.gameObject.transform.position);
		//print(distance2);
		Vector3 direction;
		//we want to see if both players are within range
		if (distance1 <= detectionRange && distance2 <= detectionRange){
			//see which player is closer
			if (distance1 < distance2){
				//direction = player1.transform.position - this.transform.position;
				//setChaseDirection(direction);
				//Vector2 speed = enemy.speed * Time.deltaTime;
				transform.position = Vector2.MoveTowards(transform.position, player1.transform.position, enemy.speed.x * Time.deltaTime);
			}
			else{
				//direction = player2.transform.position - this.transform.position;
				//setChaseDirection(direction);
				transform.position = Vector2.MoveTowards(transform.position, player2.transform.position, enemy.speed.x * Time.deltaTime);

			}
		}
		//or if player 1 is in range
		else if (distance1 <= detectionRange){
			//direction = player1.transform.position - this.transform.position;
			//setChaseDirection(direction);
			transform.position = Vector2.MoveTowards(transform.position, player1.transform.position, enemy.speed.x*Time.deltaTime);

		}
		//or if player 2 is in range
		else if (distance2 <= detectionRange){
			//direction = player2.transform.position - this.transform.position;
			//setChaseDirection(direction);
			transform.position = Vector2.MoveTowards(transform.position, player2.transform.position, enemy.speed.x*Time.deltaTime);

		}


	}

	/*public void setChaseDirection(Vector3 direction){
		direction.Normalize();
		//Vector2 x = direction.x * enemy.speed * Time.deltaTime;
		//Vector2 y = direction.y * enemy.speed * Time.deltaTime;
		this.transform.Translate(direction.x * enemy.speed * Time.deltaTime,
		                         direction.y * enemy.speed * Time.deltaTime,
		                         0,
		                         Space.World);
	}*/

}
