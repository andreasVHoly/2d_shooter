﻿using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	//how much health the object has
	public int health = 100;
	//if the object should be identified as an enemy
	public bool isEnemy = true;

	public GameObject scripts;

	public HealthBarScript bar;


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
					Destroy (gameObject);
				}
			}
			else{//if the entity we are hitting is not an enemy, we just want to handle the collision differently
				if (gameObject.name == "Metal Box"){
					Destroy(entity.gameObject);
				}
			}
		}

		else if(collider.name == "Enemy" && (this.gameObject.name == "Player 1" || this.gameObject.name == "Player 2")){
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
		}
		else if(collider.name == "Enemy" && (this.gameObject.name == "Metal Box" || this.gameObject.name == "Box")){

			EnemyMovementScript enemy = collider.gameObject.GetComponent<EnemyMovementScript>();
			DirectionEnumScript.Direction dir = DirectionEnumScript.getOpposite(enemy.orientation);
			if (dir == DirectionEnumScript.Direction.NORTH){
				enemy.direction = new Vector2(0,1);
			}
			else if (dir == DirectionEnumScript.Direction.SOUTH){
				enemy.direction = new Vector2(0,-1);
			}
		else if (dir == DirectionEnumScript.Direction.EAST){
				enemy.direction = new Vector2(1,0);
			}
			else {
				enemy.direction = new Vector2(-1,0);
			}
		}
		else if(collider.name == "Enemy" &&  this.gameObject.name == "Enemy"){
			collider.gameObject.GetComponent<EnemyMovementScript>().move = true;
			this.gameObject.GetComponent<EnemyMovementScript>().move = true;
		}

		else if (collider.name == "AmmoPack"){
			this.gameObject.GetComponent<WeaponScript>().ammo = 260;
			Destroy(collider.gameObject);

		}
		else if (collider.name == "HealthPack"){
			this.gameObject.GetComponent<HealthScript>().health = 100;
			Destroy(collider.gameObject);
		}
		else if (collider.name == "BatteryPack"){
			this.gameObject.GetComponent<BatteryScript>().charge = 100;
			Destroy(collider.gameObject);
		}
		else if (collider.name == "Spawn"){
			if(this.gameObject.name == "Player 1"){
				scripts.GetComponent<LevelLoaderScript>().player1 = true;
			}
			else if(this.gameObject.name == "Player 2"){
				scripts.GetComponent<LevelLoaderScript>().player2 = true;
			}
		}


	}
}
