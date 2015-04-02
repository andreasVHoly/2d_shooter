using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoCountScript : MonoBehaviour {

	public int amount = 100;
	
	// Update is called once per frame
	void Update () {
		Text counter = GetComponent<Text>();
		counter.text = "Ammo: " + amount;
	}
}
