using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BatteryUIScript : MonoBehaviour {

	//amount of charge we have in the bar
	public float amount;
	
	// Update is called once per frame
	//NOTE: values lie between 0 and 1, 1 being 100% charged and 0 being 0% charged
	void Update () {
		//we get the image component, which is our battery
		Image image = GetComponent<Image>();
		if (image.fillAmount != amount){//if something has changed
			image.fillAmount = Mathf.MoveTowards(image.fillAmount, amount, (float)(Time.deltaTime * 0.25));//we increase/decrease the fill amount of the bar
		}
		if (image.fillAmount <= 0.20){//if we have less= 20% charge
			image.color = Color.red;//change the color to red
		}
		else if (image.fillAmount > 0.20){//if we have less= 20% charge
			image.color = Color.green;//change the color to red
		}
	}
}
