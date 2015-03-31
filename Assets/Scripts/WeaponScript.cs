using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	

	//the delay in between shots
	public float delay = 0.25f;

	//a transform for our new bullet to be spawned
	public Transform bullet;


	// Update is called once per frame
	void Update () {
		//shooting key for player 2
		if (Input.GetKeyDown (KeyCode.RightControl) && this.gameObject.name == "Player 2") {
			this.spawnBullet();
		}
		//shooting key for player 1
		if (Input.GetKeyDown (KeyCode.LeftControl) && this.gameObject.name == "Player 1") {
			this.spawnBullet ();
		}
	}

	//spawns a bullet at the players location
	void spawnBullet(){
		//we make a new bullet
		var shot = Instantiate(bullet) as Transform;
		//we set the position to the position of the current game object
		shot.position = this.transform.position;
		//we get the dsired direction of the bullet based on the current game objects direction
		SingleDirMovementScript bulletMovement = shot.gameObject.GetComponent<SingleDirMovementScript>();
		//if we got a valid return
		if (bulletMovement != null){
			//we set the direction approriately
			//print ("if entered");
			bulletMovement.setDirection(this.gameObject.GetComponent<PlayerMovementScript>().direction);
		}
	}


}