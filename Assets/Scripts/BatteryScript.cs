using UnityEngine;
using System.Collections;


/**
 * This class is not used, was for 
 */
public class BatteryScript : MonoBehaviour {

	public float charge = 100;

	public float drain = 0.025f;

	public bool lighting = true;
	
	// Update is called once per frame
	void Update () {
		charge -= drain;

		if (charge <= 0){
			//lights go out
			lighting = false;
		}
	}
}
