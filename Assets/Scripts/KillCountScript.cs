using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * This class handles the kill counter in the UI part of the game
 */
public class KillCountScript : MonoBehaviour {
	//default
	public int amount = 0;
	
	// Update is called once per frame
	void Update () {
		//updates the amount every frame
		Text counter = GetComponent<Text>();
		counter.text = "" + amount;
	}
}
