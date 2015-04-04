using UnityEngine;
using System.Collections;

/**
 * This class handles all the sound in the game
 * it contains all the sounds and also has methods to play each indivual sound
 */
public class SoundScript : MonoBehaviour {


	//NOTE: all the sounds need to be assigned in unity

	public AudioClip ammo;//sound for pciking up an ammo box
	public AudioClip health;//sound for picking up a health pack
	public AudioClip teleport;//sound for walking over a teleporter
	public AudioClip death;//sound for a player dying
	public AudioClip pain;//sound for a player getting damaged
	public AudioClip shot;//sound for a gun being fired

	//24 individual zombie sounds
	public AudioClip zombie0;
	public AudioClip zombie1;
	public AudioClip zombie2;
	public AudioClip zombie3;
	public AudioClip zombie4;
	public AudioClip zombie5;
	public AudioClip zombie6;
	public AudioClip zombie7;
	public AudioClip zombie8;
	public AudioClip zombie9;
	public AudioClip zombie10;
	public AudioClip zombie11;
	public AudioClip zombie12;
	public AudioClip zombie13;
	public AudioClip zombie14;
	public AudioClip zombie15;
	public AudioClip zombie16;
	public AudioClip zombie17;
	public AudioClip zombie18;
	public AudioClip zombie19;
	public AudioClip zombie20;
	public AudioClip zombie21;
	public AudioClip zombie22;
	public AudioClip zombie23;


	//we have an array containing all the 24 zombie sounds
	private AudioClip[] zombie;

	void Start(){
		//init, adding all sounds
		zombie = new AudioClip[24] {zombie0, zombie1,zombie2,zombie3,zombie4,zombie5,zombie6,zombie7,zombie8,zombie9,zombie10,
			zombie11,zombie12,zombie13,zombie14,zombie15,zombie16,zombie17,zombie18,zombie19,zombie20,
			zombie21,zombie22,zombie23};
	}

	//we play a randomly selected zombie sound
	public void playZombieSound(){
		int clip = Random.Range(0,23);
		playSound(zombie[clip]);
	}

	//we play a gun shot sound
	public void playShotSound(){
		playSound(shot);
	}

	//we play a pain sound
	public void playPainSound(){
		playSound(pain);
	}

	//we play a death sound
	public void playDeathSound(){
		playSound(death);
	}

	//we play a sound for the beacon
	public void playTeleportSound(){
		playSound(teleport);
	}

	//we play a sound for absorbing health
	public void playHealthSound(){
		playSound(health);
	}

	//we play a sound for picking up ammo
	public void playAmmoSound(){
		playSound(ammo);
	}
	
	//this method takes a sound clip in and plays it at some random position, the position is not relevant
	private void playSound(AudioClip sound){
		AudioSource.PlayClipAtPoint(sound,transform.position);
	}

}
