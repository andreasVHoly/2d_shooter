using UnityEngine;
using System.Collections;

/**
 * This class represent the bullets atributes and handles its clean up if it does not hi anything
 * it includes the damage it does and also the object that fired it
 */
public class BulletScript : MonoBehaviour {

	//amount of damage the bullet inflicts
	public int damage = 20;	
	//the parent of the bullet, ie which object shot the bullet
	public GameObject parent;

	//called on start
	void Start(){
		//we want to destroy the object manually after 5 seconds if we don't hit anything
		//if we do hit something before 5s, we manually delete the bullet there
		Destroy (gameObject, 5);	
	}

}
















