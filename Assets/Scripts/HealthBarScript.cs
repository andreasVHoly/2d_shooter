using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * This class handles the health bar for each player
 * It moves the bar according to the health of the player and changes color based on its amount
 */
public class HealthBarScript : MonoBehaviour {

	//amount of health we have in the bar
	public float amount;

	// Update is called once per frame
	//NOTE: values lie between 0 and 1, 1 being 100% health and 0 being 0% health
	void Update () {
		//we get the image component, which is our healthbar
		Image image = GetComponent<Image>();
		if (image.fillAmount != amount){//if something has changed
			image.fillAmount = Mathf.MoveTowards(image.fillAmount, amount, (float)(Time.deltaTime * 0.25));//we increase/decrease the fill amount of the bar
		}
		if (image.fillAmount <= 0.25){//if we have less= 25% health
			image.color = Color.red;//change the color to red
		}
		else if (image.fillAmount <= 0.5){//if we have less= 50% health
			image.color = Color.yellow;//change the color to yellow
		}
		if (image.fillAmount <= 0.25){//if we have less= 25% health
			image.color = Color.red;//change the color to red
		}
		else if (image.fillAmount > 0.5){//if we have less= 50% health
			image.color = Color.green;//change the color to yellow
		}
	}
}
