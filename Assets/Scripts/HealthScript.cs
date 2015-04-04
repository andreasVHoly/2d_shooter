﻿using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	//how much health the object has
	public int health = 100;
	//if the object should be identified as an enemy
	public bool isEnemy = true;

	public GameObject scripts;

	public HealthBarScript bar;

	public KillCountScript kills;
	
	private SoundScript sound;


	public void takeDamage(GameObject entity, int amount){
		HealthScript script = entity.gameObject.GetComponent<HealthScript>();
		script.health -= amount;
		script.bar.amount = (float)(script.health/100.0);
		if (script.health <= 0){
			sound.playDeathSound();
			PlayerPrefs.DeleteKey("Score");
			PlayerPrefs.SetInt("Score",kills.amount);
			PlayerPrefs.Save();
			if (script.gameObject.name == "Player 1"){
				script.scripts.GetComponent<LevelLoaderScript>().player1Dead = true;
			}
			else if(script.gameObject.name == "Player 2"){
				script.scripts.GetComponent<LevelLoaderScript>().player2Dead = true;
			}
			Destroy(script.gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if(scripts != null){
			sound = scripts.GetComponent<SoundScript>();
		}
		bool player2a = coll.gameObject.name == "Player 2";
		bool player2b = this.gameObject.name == "Player 2";
		bool player1a = coll.gameObject.name == "Player 1";
		bool player1b = this.gameObject.name == "Player 1";
		bool enemy1 = coll.gameObject.name == "Enemy";
		bool enemy2 = this.gameObject.name == "Enemy";
		bool box1 = coll.gameObject.name == "Box";
		bool box2 = this.gameObject.name == "Box";
		bool mBox1 = coll.gameObject.name == "Metal Box";
		bool mBox2 = this.gameObject.name == "Metal Box";

		//player is coll, enemy is this
		if((player2a || player1a) && enemy2){
			int amount = this.gameObject.GetComponent<EnemyMovementScript>().damage;
			takeDamage(coll.gameObject,amount);
			if (sound != null){
				sound.playPainSound();
			}


			Destroy(this.gameObject);
		}
		//player is this, enemy is coll
		else if((player2b || player1b) && enemy1){
			sound.playPainSound();
			int amount = coll.gameObject.GetComponent<EnemyMovementScript>().damage;
			takeDamage(this.gameObject,amount);
			Destroy(coll.gameObject);
		}
		else if(enemy1 && enemy2){
			this.gameObject.GetComponent<EnemyMovementScript>().move = true;
			coll.gameObject.GetComponent<EnemyMovementScript>().move = true;
		}
		//enemy1 is coll, box is this
		else if (enemy1 && (mBox2 || box2)){
			//print("box " + coll.gameObject.GetComponent<EnemyMovementScript>());
			coll.gameObject.GetComponent<EnemyMovementScript>().move = true;
		}
		//enemy is this, box is coll
		else if (enemy2 && (mBox1 || box1)){
			//print("box2 " + this.gameObject.GetComponent<EnemyMovementScript>());
			this.gameObject.GetComponent<EnemyMovementScript>().move = true;
		}

	}


	//we want to hande collisions manually in order to reduce health
	void OnTriggerEnter2D(Collider2D collider){
		//we access the colliding entity and look if the colliding game object has the bullet script as a component
		//if this is true, this object must be a bullet, as only bullets own this component
		//print(collider.name);
		BulletScript entity = collider.gameObject.GetComponent<BulletScript> ();
		//we check if the game object actually had the bullet script
		if (entity !=  null) {
			//if the bullet hits an object that is not an enemy, we don't want it to reduce health
			if (isEnemy){
				//we deduct the amount of damage the bullet does
				health -= entity.damage;

				//we destroy the bullet as it has had an impact
				Destroy(entity.gameObject);



				//if this object has no health anymore, we destroy it as it is dead
				if (health <= 0){
					if(this.gameObject.name == "Enemy"){
						kills.amount += 1;
						sound.playZombieSound();
					}
					Destroy (gameObject);
				}
			}
			else{//if the entity we are hitting is not an enemy, we just want to handle the collision differently
				if (gameObject.name == "Metal Box"){
					Destroy(entity.gameObject);
				}
			}
		}

		/*else if(collider.name == "Enemy" && (this.gameObject.name == "Player 1" || this.gameObject.name == "Player 2")){
			this.health -= collider.GetComponent<EnemyMovementScript>().damage;
			bar.amount = (float)(health/100.0);
			//print(health/100);
			//print("health deducted");
			Destroy(collider.gameObject);
			if (health <= 0){
				if (this.gameObject.name == "Player 1"){
					scripts.GetComponent<LevelLoaderScript>().player1Dead = true;
				}
				else{
					scripts.GetComponent<LevelLoaderScript>().player2Dead = true;
				}
				Destroy(this.gameObject);
			}
		}*/
		/*else if((collider.name == "Player 1" || collider.name == "Player 2") && (this.gameObject.name == "Metal Box" || this.gameObject.name == "Box")){

			collider.gameObject.GetComponent<PlayerMovementScript>().colliding = true;
			collider.gameObject.GetComponent<PlayerMovementScript>().collider_ = collider;
		}*/


		else if (collider.name == "AmmoPack"){
			WeaponScript wscript = this.gameObject.GetComponent<WeaponScript>();
			wscript.ammo =100;
			//updating the ui
			wscript.ammoScript.amount = wscript.ammo;
			Destroy(collider.gameObject);
			sound.playAmmoSound();

		}
		else if (collider.name == "HealthPack"){

			takeDamage(this.gameObject, health-100);
			Destroy(collider.gameObject);
			sound.playHealthSound();
		}
		else if (collider.name == "BatteryPack"){
			this.gameObject.GetComponent<BatteryScript>().charge = 100;
			Destroy(collider.gameObject);
		}
		else if (collider.name == "Spawn"){
			if(this.gameObject.name == "Player 1"){
				scripts.GetComponent<LevelLoaderScript>().player1 = true;
				sound.playTeleportSound();
				this.gameObject.SetActive(false);
				PlayerPrefs.DeleteKey("P1 health");
				PlayerPrefs.DeleteKey("P1 ammo");
				PlayerPrefs.DeleteKey("Score");
				PlayerPrefs.SetInt("P1 health",health);
				PlayerPrefs.SetInt("P1 ammo",this.gameObject.GetComponent<WeaponScript>().ammo);
				PlayerPrefs.SetInt("Score",kills.amount);
				PlayerPrefs.Save();
			}
			else if(this.gameObject.name == "Player 2"){
				scripts.GetComponent<LevelLoaderScript>().player2 = true;
				this.gameObject.SetActive(false);
				sound.playTeleportSound();
				PlayerPrefs.DeleteKey("P2 health");
				PlayerPrefs.DeleteKey("P2 ammo");
				PlayerPrefs.DeleteKey("Score");
				PlayerPrefs.SetInt("P2 health",health);
				PlayerPrefs.SetInt("P2 ammo",this.gameObject.GetComponent<WeaponScript>().ammo);
				PlayerPrefs.SetInt("Score",kills.amount);
				PlayerPrefs.Save();
				

				

			}
		}


	}
}
