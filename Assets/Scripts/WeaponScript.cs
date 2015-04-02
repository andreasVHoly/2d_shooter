using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	

	//the delay in between shots
	public float delay = 0.25f;


	//ammo variable
	public int ammo = 100;

	public AmmoCountScript ammoScript;

	//a transform for our new bullet to be spawned
	public Transform bullet;


	// Update is called once per frame
	void Update () {
		//shooting key for player 2
		if (Input.GetKeyDown (KeyCode.RightControl) && this.gameObject.name == "Player 2") {
			if(ammo > 0){
				this.spawnBullet ();
				this.ammo--;
				ammoScript.amount = this.ammo;
			}
		}
		//shooting key for player 1
		if (Input.GetKeyDown (KeyCode.LeftControl) && this.gameObject.name == "Player 1") {
			if(ammo > 0){
				this.spawnBullet ();
				this.ammo--;
				ammoScript.amount = this.ammo;
			}
		}
	}

	//spawns a bullet at the players location
	void spawnBullet(){
		//we make a new bullet
		var shot = Instantiate(bullet) as Transform;

		//we get the current objects direction
		DirectionEnumScript.Direction dir =  this.gameObject.GetComponent<PlayerMovementScript>().direction;
		//default
		shot.position = this.transform.position;

		//we get the desired direction of the bullet based on the current game objects direction
		SingleDirMovementScript bulletMovement = shot.gameObject.GetComponent<SingleDirMovementScript>();
		//if we got a valid return
		if (bulletMovement != null){
			//we set the direction approriately based on the current objects direction

			bulletMovement.setDirection(dir);
		}
		//we set the position to the position of the current game object

	}


}