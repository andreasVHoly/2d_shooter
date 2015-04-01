using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	

	//the delay in between shots
	public float delay = 0.25f;


	//ammo variable
	public int ammo = 5;

	//a transform for our new bullet to be spawned
	public Transform bullet;


	// Update is called once per frame
	void Update () {
		//shooting key for player 2
		if (Input.GetKeyDown (KeyCode.RightControl) && this.gameObject.name == "Player 2") {
			if(ammo > 0){
				this.spawnBullet ();
				this.ammo--;
			}
		}
		//shooting key for player 1
		if (Input.GetKeyDown (KeyCode.LeftControl) && this.gameObject.name == "Player 1") {
			if(ammo > 0){
				this.spawnBullet ();
				this.ammo--;
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
		//trying to spawn the bullet at the right location
		//Vector3 pos;
		//we need to set the bullet to be at the edge of the sprite


		/*if (dir == DirectionEnumScript.Direction.NORTH){
			//shot.transform.rotation = Qu
			shot.transform.Rotate(new Vector3(0,0,-90));
		//	pos = new Vector3(this.transform.position.x,this.transform.position.y,0) ;
		}
		else if (dir == DirectionEnumScript.Direction.SOUTH){
			shot.transform.Rotate(new Vector3(0,0,90));
		//	pos = new Vector3(this.transform.position.x,this.transform.position.y,0) ;
		}
		else if (dir == DirectionEnumScript.Direction.EAST){
			shot.transform.Rotate(new Vector3(0,0,180));

		//	pos = new Vector3(this.transform.position.x,this.transform.position.y,0) ;
		}*/


		//else {
		//	pos = new Vector3(this.transform.position.x,this.transform.position.y,0) ;
		//}
		//shot.position = pos;




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