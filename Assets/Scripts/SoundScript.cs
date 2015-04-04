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
