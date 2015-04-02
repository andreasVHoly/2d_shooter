using UnityEngine;
using System.Collections;

public class EdgeScript : MonoBehaviour {


	public Transform box;


	private float sWidth;
	private float sHeight;
	private float boxHeight;
	private float boxWidth;
	private int amountW;
	private int amountH;


	// Use this for initialization
	void Start () {
		sWidth = Screen.width;
		sHeight = Screen.height;
		boxWidth = box.collider2D.bounds.size.x;
		boxHeight = box.collider2D.bounds.size.y;
		amountW = (int)(sWidth/boxWidth);
		amountH = (int)(sHeight/boxHeight);
		amountH -= 2;
		for (int x = 0; x < amountW; x += (int)boxWidth){
			var box1 = Instantiate(box) as Transform;
			box1.position = new Vector3(x,0,5);
			var box2 = Instantiate(box) as Transform;
			box2.position = new Vector3(x,sHeight-boxHeight,5);
		}
		for (int y = 0; y < amountW; y += (int)boxHeight){
			var box1 = Instantiate(box) as Transform;
			box1.position = new Vector3(0,y,5);
			var box2 = Instantiate(box) as Transform;
			box2.position = new Vector3(sWidth-boxWidth,y,5);
		}

	}
	

}
