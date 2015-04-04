using UnityEngine;
using UnityEngine.UI;
using System.Collections;


/**
 * this class handles the ui ammo counter for each player
 */
public class AmmoCountScript : MonoBehaviour {

	//the amount to be displayed, default is 100 as players get 100 at start
	public int amount = 100;
	
	// Update is called once per frame
	void Update () {
		//diplay amount every frame
		Text counter = GetComponent<Text>();
		counter.text = "Ammo: " + amount;
	}
}
