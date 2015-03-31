using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	//how much health the object has
	public int health = 100;
	//if the object should be identified as an enemy
	public bool isEnemy = true;

	//we want to hande collisions manually in order to reduce health
	void OnTriggerEnter2D(Collider2D collider){
		//we access the colliding entity and look if the colliding game object has the bullet script as a component
		//if this is true, this object must be a bullet, as only bullets own this component
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
	}
}
