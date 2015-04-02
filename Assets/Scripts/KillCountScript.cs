using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KillCountScript : MonoBehaviour {

	public int amount = 0;
	
	// Update is called once per frame
	void Update () {
		Text counter = GetComponent<Text>();
		counter.text = "" + amount;
	}
}
