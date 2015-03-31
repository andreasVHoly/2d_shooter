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
			spawnBullet();
		}
		//shooting key for player 1
		if (Input.GetKeyDown (KeyCode.LeftControl) && this.gameObject.name == "Player 1") {
			spawnBullet ();
		}
	}

	//spawns a bullet at the players location
	public void spawnBullet(){
		//we make a new bullet
		var shot = Instantiate(bullet) as Transform;
		//we set the position to the position of the current game object
		shot.position = this.transform.position;
		//we want to ignore collisions between the bullet and its parent object

		//if(this.gameObject.GetComponent<Collider2D>() != null){
			//print ("method entered");
		//print (shot.gameObject.layer);
		//print (gameObject.layer);

		//Physics2D.IgnoreCollision(shot.collider2D, this.gameObject.collider2D);
		//}
		//we get the dsired direction of the bullet based on the current game objects direction
		SingleDirMovementScript bulletMovement = shot.gameObject.GetComponent<SingleDirMovementScript>();
		//if we got a valid return
		if (bulletMovement != null){
			//we set the direction approriately
			print ("if entered");
			//bulletMovement.direction = this.transform.forward;
		}
	}


}