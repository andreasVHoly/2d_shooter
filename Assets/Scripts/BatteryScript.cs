using UnityEngine;
using System.Collections;


/**
 * this class handles the battery effect of a players flashlight by slowly dimming it and making it smaller
 */
 public class BatteryScript : MonoBehaviour {

	//the charge of the battery
	private float charge;
	//the original charge if we want to reload batteries
	private float fullCharge;
	//lowest lit point
	public float empty;
	//lowest shrunk point
	public float shrunk;
	//the amount the light dims per frame
	public float discharge = 0.002f;
	//the objects light
	private Light flashLight;
	//our battery ui script to control the ui battery NOTE: needs to be assigned in unity
	public BatteryUIScript battery;


	// Use this for initialization
	void Start () {
		//find the objects light
		flashLight = this.gameObject.GetComponent<Light>();
		//we set the charge to the start intensity of the light, we multiply by 10 for the dimming effect to slow down
		charge = flashLight.intensity*10f;
		shrunk = 4f;
		empty = 0.2f;
		fullCharge = flashLight.intensity;
	}
	
	// Update is called once per frame
	void Update () {
		if (charge/10 > empty){//if the intensity is above 0.2
			charge -= discharge;//we reduce the intensity
		}
		else if (flashLight.cookieSize > shrunk){//if it is below 0.2, we shrink the area the light covers up until a radius of 4
			flashLight.cookieSize -= discharge;
		}
		flashLight.intensity = charge/10f;//we update the catual value
		battery.amount = flashLight.intensity/fullCharge;
	}

	//recharges the flah light to its original capacity
	public void recharge(){
		charge = fullCharge*10f;
	}
}
