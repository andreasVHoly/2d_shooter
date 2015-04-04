using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {


	public AudioClip ammo;
	public AudioClip health;
	public AudioClip teleport;
	public AudioClip death;
	public AudioClip pain;
	public AudioClip shot;
	public AudioClip step;
	public AudioClip gameOver;

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





	private AudioClip[] zombie;

	void Start(){
		zombie = new AudioClip[24] {zombie0, zombie1,zombie2,zombie3,zombie4,zombie5,zombie6,zombie7,zombie8,zombie9,zombie10,
			zombie11,zombie12,zombie13,zombie14,zombie15,zombie16,zombie17,zombie18,zombie19,zombie20,
			zombie21,zombie22,zombie23};
	}


	public void playZombieSound(){
		int clip = Random.Range(0,23);
		playSound(zombie[clip]);
	}

	public void playShotSound(){
		playSound(shot);
	}
	public void playGameOverSound(){
		playSound(gameOver);
	}
	public void playStepSound(){
		playSound(step);
	}
	public void playPainSound(){
		playSound(pain);
	}
	public void playDeathSound(){
		playSound(death);
	}
	public void playTeleportSound(){
		playSound(teleport);
	}
	public void playHealthSound(){
		playSound(health);
	}
	public void playAmmoSound(){
		playSound(ammo);
	}
	

	private void playSound(AudioClip sound){
		AudioSource.PlayClipAtPoint(sound,transform.position);
	}

}
