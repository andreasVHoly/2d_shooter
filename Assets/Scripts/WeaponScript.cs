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
		if (Input.GetKeyDown (KeyCode.LeftAlt) && this.gameObject.name == "Player 1") {
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

		Vector3 newPos = this.transform.position;
		float x = this.transform.position.x;
		float y = this.transform.position.y;

		float width = this.transform.collider2D.bounds.size.x/2;
		float height = this.transform.collider2D.bounds.size.y/2;

		float offset = 0.1f;


		switch(dir){
		case DirectionEnumScript.Direction.NORTH:
			//move x pos right and y pos up
			newPos = new Vector3(x+width-offset,y+height,0);
			break;
		case DirectionEnumScript.Direction.SOUTH:
			//move x pos left and y pos down
			newPos = new Vector3(x-width+offset,y-height,0);
			break;
		case DirectionEnumScript.Direction.WEST:
			//move y pos up and x pos left
			newPos = new Vector3(x-width,y+height-offset,0);
			break;
		case DirectionEnumScript.Direction.EAST:
			//move y pos down and x pos right
			newPos = new Vector3(x+width,y-height+offset,0);
			break;
		}
			
		//default
		//shot.position = this.transform.position;
		shot.position = newPos;

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