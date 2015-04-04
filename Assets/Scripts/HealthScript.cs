using UnityEngine;
using System.Collections;

/**
 * this script handles all atrruvutes to do with health and also updates most UI elements 
 * this script is assigned to all elements that can loose health (enemies, players, boxes)
 */
public class HealthScript : MonoBehaviour {

	//how much health the object has
	public int health = 100;
	//if the object should be identified as an enemy, ie should be damaged by bullets
	public bool isEnemy = true;
	//our sound object to make noises
	private SoundScript sound;

	//NOTE: objects below need to be set in unity

	//the scripts folder to access the sound manager
	public GameObject scripts;
	//the health bar script for this object in order to manage this ui attribute
	public HealthBarScript bar;
	//the script to updated the kill counter ui 
	public KillCountScript kills;

	//used to increase/decrease the health of an obeject and to manage the ui afterwards
	public void takeDamage(GameObject entity, int amount){
		//we get the health script of the entity we are updating
		HealthScript script = entity.gameObject.GetComponent<HealthScript>();
		script.health -= amount;//we reduce/add health by the amount ( if we want to add we need to send a negative value into the function)
		script.bar.amount = (float)(script.health/100.0);//we update the ui health bar
		if (script.health <= 0){//if this entity is dead 
			sound.playDeathSound();//we play the death sound
			PlayerPrefs.DeleteKey("Score");//we delete the previously set value (if any)
			PlayerPrefs.SetInt("Score",kills.amount);//we add in the new amount of kills 
			PlayerPrefs.Save();//we save the prefs
			if (script.gameObject.name == "Player 1"){//if player 1
				script.scripts.GetComponent<LevelLoaderScript>().player1Dead = true;//we set player 1's state to dead
			}
			else if(script.gameObject.name == "Player 2"){//if player 2
				script.scripts.GetComponent<LevelLoaderScript>().player2Dead = true;//we set player 2's state to dead
			}
			Destroy(script.gameObject);//we destroy the object
		}
	}

	//hanlde collision of objects that are not triggers
	void OnCollisionEnter2D(Collision2D coll){
		//get the sound script
		if(scripts != null){
			sound = scripts.GetComponent<SoundScript>();
		}

		// we create booleans based on the collisions situation in order to only handle specific ones
		bool player2 = this.gameObject.name == "Player 2"; // if this is player 2
		bool player1 = this.gameObject.name == "Player 1"; // if this is player 1
		bool enemy1 = coll.gameObject.name == "Enemy"; // if the colldier is an enemy
		bool enemy2 = this.gameObject.name == "Enemy"; // if this is an enemy
		bool box = this.gameObject.name == "Box"; // if this is a box
		bool mBox = this.gameObject.name == "Metal Box"; // if this is a metal box

		//player is this, enemy is coll
		if((player2 || player1) && enemy1){
			sound.playPainSound();//play sound
			int amount = coll.gameObject.GetComponent<EnemyMovementScript>().damage;//damage amount
			takeDamage(this.gameObject,amount);//reduce health
			Destroy(coll.gameObject);//destroy the enemy
		}
		//if an enemy collides with an enemy
		else if(enemy1 && enemy2){
			//we set the move variable in the enemy movement script to true, which overrides its usual movement patterns and forces a change in direction
			//we do this for both enemies
			this.gameObject.GetComponent<EnemyMovementScript>().move = true;
			coll.gameObject.GetComponent<EnemyMovementScript>().move = true;
		}
		//enemy1 is coll, box is this
		else if (enemy1 && (mBox || box)){
			coll.gameObject.GetComponent<EnemyMovementScript>().move = true;//we force the enemy to move
		}

	}


	//hande trigger collisions manually
	void OnTriggerEnter2D(Collider2D collider){
		//we access the colliding entity and look if the colliding game object has the bullet script as a component
		//if this is true, this object must be a bullet, as only bullets own this component
		BulletScript entity = collider.gameObject.GetComponent<BulletScript> ();
		//we check if the game object actually had the bullet script, if it does not we have another type of trigger
		if (entity !=  null) {
			//if the bullet hits an object that is not an enemy, we don't want it to reduce health
			if (isEnemy){
	
				//we deduct the amount of damage the bullet does
				health -= entity.damage;
				//we get an enemy movement script (only enemies have this, hence the check in the next line)
				EnemyMovementScript enemy = this.gameObject.GetComponent<EnemyMovementScript>();
				if (enemy != null){
					enemy.chasing = true;//we enable chasing
					enemy.prey = entity.parent;//we set the prey to the player that shot the bullet
					enemy.overRide = true;//we enable a override method so that the enemy keeps on chasing the player who shot it
				}

				//we destroy the bullet as it has had an impact
				Destroy(entity.gameObject);

				//if this object we hit has no health anymore, we destroy it as it is dead
				if (health <= 0){
					if(this.gameObject.name == "Enemy"){//if it is an enemy, we add to the games kill counter
						kills.amount += 1;
						sound.playZombieSound();//we play a zombie sound
					}
					Destroy (gameObject);//we destroy the zombie
				}
			}
			else{//if the entity we are hitting is not an enemy, we just want to handle the collision differently
				if (gameObject.name == "Metal Box"){
					Destroy(entity.gameObject);//destroy the bullet, as metal boxes are used as walls
				}
			}
		}
		//if we have trigger collision with an ammo pack
		else if (collider.name == "AmmoPack"){
			//we get the script in charge of ammo
			WeaponScript wscript = this.gameObject.GetComponent<WeaponScript>();
			wscript.ammo = 100;//we reset ammo
			//updating the ui
			wscript.ammoScript.amount = wscript.ammo;
			//we destroy the ammo crate
			Destroy(collider.gameObject);
			//we play a sound for picking up the ammo pack
			sound.playAmmoSound();
		}
		//if we have trigger collision with a health pack
		else if (collider.name == "HealthPack"){
			//we increase health to 100 again by the difference
			takeDamage(this.gameObject, health-100);
			//we destroy the health crate
			Destroy(collider.gameObject);
			//we play a sound for picking up the health pack
			sound.playHealthSound();
		}
		//if we have trigger collision with a beacon
		else if (collider.name == "Spawn"){
			//if player 1 is on the beacon
			if(this.gameObject.name == "Player 1"){
				scripts.GetComponent<LevelLoaderScript>().player1 = true;//we set player 1's ready flag
				sound.playTeleportSound();//we play a sound
				this.gameObject.SetActive(false);//we set the object as inactive
				PlayerPrefs.DeleteKey("P1 health");//we delete previous entry (if any)
				PlayerPrefs.DeleteKey("P1 ammo");//we delete previous entry (if any)
				PlayerPrefs.DeleteKey("Score");//we delete previous entry (if any)
				PlayerPrefs.SetInt("P1 health",health);//we set new entry, this will be used if we go to the next level
				PlayerPrefs.SetInt("P1 ammo",this.gameObject.GetComponent<WeaponScript>().ammo);//we set new entry, this will be used if we go to the next level
				PlayerPrefs.SetInt("Score",kills.amount);//we set new entry, for the gamewon/gameover scene
				PlayerPrefs.Save();//we save the changes
			}
			//if player 2 is on the beacon
			else if(this.gameObject.name == "Player 2"){
				scripts.GetComponent<LevelLoaderScript>().player2 = true;//we set player 2's ready flag
				this.gameObject.SetActive(false);//we set the object as inactive
				sound.playTeleportSound();//we play a sound
				PlayerPrefs.DeleteKey("P2 health");//we delete previous entry (if any)
				PlayerPrefs.DeleteKey("P2 ammo");//we delete previous entry (if any)
				PlayerPrefs.DeleteKey("Score");//we delete previous entry (if any)
				PlayerPrefs.SetInt("P2 health",health);//we set new entry, this will be used if we go to the next level
				PlayerPrefs.SetInt("P2 ammo",this.gameObject.GetComponent<WeaponScript>().ammo);//we set new entry, this will be used if we go to the next level
				PlayerPrefs.SetInt("Score",kills.amount);//we set new entry, for the gamewon/gameover scene
				PlayerPrefs.Save();//we save the changes
			}
		}


	}
}
