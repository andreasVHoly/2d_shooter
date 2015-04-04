using UnityEngine;
using System.Collections;

/*
 * This class handles all the weapon based variables and the creating of bullets for a object
 * Further it checks for input from both players if they are shooting
 */
public class WeaponScript : MonoBehaviour {

	//ammo variablem, how much ammo the player has
	public int ammo = 100;


	//NOTE: variables below need to be assigned in unity, otherwise nullptr
	
	//the script that handles the UI ammo counter
	public AmmoCountScript ammoScript;
	//a transform for our new bullet to be spawned
	public Transform bullet;
	//the scripts folder in order to access sounds
	public GameObject scripts;
	//the sound script
	private SoundScript sound;

	//called on start
	void Start(){
		sound = scripts.GetComponent<SoundScript>();//init
	}

	// Update is called once per frame
	void Update () {
		//shooting key for player 2
		if (Input.GetKeyDown (KeyCode.RightControl) && this.gameObject.name == "Player 2") {//if the key is pressed and the current object is player 2
			if(ammo > 0){//if we have ammo
				this.spawnBullet ();//call method that spawns bullets and handles variable updates
			}
		}
		//shooting key for player 1
		if (Input.GetKeyDown (KeyCode.LeftAlt) && this.gameObject.name == "Player 1") {//if the key is pressed and the current object is player 1
			if(ammo > 0){//if we have ammo
				this.spawnBullet ();//call method that spawns bullets and handles variable updates
			}
		}
	}


	//spawns a bullet at the desired location in the desired direction
	//also updates all needed vraiables and UI
	void spawnBullet(){
		//we make a new bullet
		var shot = Instantiate(bullet) as Transform;
		//get the bullet script to set the parent, we set the parent so that if the bullet hits an enemy, the enemy knows which player to chase
		shot.GetComponent<BulletScript>().parent = this.gameObject;
		//we get the current objects direction
		DirectionEnumScript.Direction dir =  this.gameObject.GetComponent<PlayerMovementScript>().direction;


		//next we calculate where to spawn the bullet and then we choose the direction and fine tune the location
		//we do this because we want the bullet to spawn at the muzzle of the gun and not on the player
		Vector3 newPos = this.transform.position;//default
		float x = newPos.x;//set old x
		float y = newPos.y;//set old y
		float width = this.transform.collider2D.bounds.size.x/2;//get width of the player object
		float height = this.transform.collider2D.bounds.size.y/2;//get height of the player object
		float offset = 0.1f;//we set a small offset to move the location in a bit

		//we no check what direction the bullet needs to be fired in and then sets its spawning location accordinly
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
		//we set the position
		shot.position = newPos;

		//we need to get the script in order to change the direction we aquired
		SingleDirMovementScript bulletMovement = shot.gameObject.GetComponent<SingleDirMovementScript>();
		//if we got a valid return, should technically never fail
		if (bulletMovement != null){
			//we set the direction approriately based on the current objects direction we got earlier
			bulletMovement.setDirection(dir);
		}
		//we play the sound for a gunshot
		sound.playShotSound();	
		//decrease ammo count by 1
		this.ammo--;
		//update  UI
		ammoScript.amount = this.ammo;
	}

}