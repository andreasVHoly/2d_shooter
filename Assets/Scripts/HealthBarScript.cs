using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarScript : MonoBehaviour {


	public float amount;

	// Update is called once per frame
	void Update () {
		Image image = GetComponent<Image>();
		image.fillAmount = Mathf.MoveTowards(image.fillAmount, amount, (float)(Time.deltaTime * 0.25));
	}
}
