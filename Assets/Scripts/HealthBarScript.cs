using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarScript : MonoBehaviour {


	public float amount;

	// Update is called once per frame
	void Update () {
		Image image = GetComponent<Image>();
		if (image.fillAmount != amount){
			image.fillAmount = Mathf.MoveTowards(image.fillAmount, amount, (float)(Time.deltaTime * 0.25));
		}
		if (image.fillAmount <= 0.25){
			image.color = Color.red;
		}
		else if (image.fillAmount <= 0.5){
			image.color = Color.yellow;
		}
	}
}
