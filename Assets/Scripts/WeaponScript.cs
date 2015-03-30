using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {



	//the delay in between shots
	public float delay = 0.25f;


	public Transform bullet;
	

	// Update is called once per frame
	void Update () {
		//shooting key for player 2
		if (Input.GetKeyDown (KeyCode.RightControl) && this.gameObject.name == "Player 2") {
			spawnBullet();
		}

		if (Input.GetKeyDown (KeyCode.LeftControl) && this.gameObject.name == "Player 1") {
			spawnBullet ();
		}
	}

	public void spawnBullet(){
		var shot = Instantiate(bullet) as Transform;
		shot.position = this.transform.position;
		Physics.IgnoreCollision(shot.GetComponent<Collider>(), this.gameObject.GetComponent<Collider>());
		SingleDirMovementScript bulletMovement = shot.gameObject.GetComponent<SingleDirMovementScript>();
		if (bulletMovement != null){
			bulletMovement.direction = this.transform.forward;
			
		}
	}


}