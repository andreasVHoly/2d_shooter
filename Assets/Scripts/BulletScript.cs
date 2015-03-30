using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	//amount of damage the bullet is suppose to inflict
	public int damage = 20;

	//boolean to check weather the bullet has been shot or not
	public bool isShot = false;
	
	
	
	void Start(){
		//we want to destroy the object manually after 5 seconds if we don't hit anything
		//if we do hit something before 5s, we manually delete the bullet there
		Destroy (gameObject, 5);	
	}
}
