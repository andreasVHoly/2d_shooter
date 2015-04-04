using UnityEngine;
using System.Collections;

public class EnemyMovementScript : MonoBehaviour {

	public Vector2 speed = new Vector2 (3, 3);
	
	public Vector2 direction = new Vector2 (0,0);

	private int counter = 120;

	public bool chasing = false;

	public int damage = 20;

	public DirectionEnumScript.Direction orientation = DirectionEnumScript.Direction.NORTH;

	public float detectionRange = 30f;
	public float chasingRange = 6.5f;

	private GameObject player1;

	private GameObject player2;

	public GameObject prey;

	public Sprite left;
	public Sprite right;
	public Sprite up;
	public Sprite down;
	private SpriteRenderer srender;
	private int travelDistance;


	public GameObject scripts;
	private SoundScript sound;
	
	public bool move = false;

	public bool overRide = false;

	void Start(){
		sound = scripts.GetComponent<SoundScript>();
		travelDistance = 120;
		srender = this.gameObject.GetComponent<SpriteRenderer>();
	}


	// Update is called once per frame
	void Update () {


		var rayCast = Physics2D.Raycast(this.transform.position, direction, detectionRange, 1 << LayerMask.NameToLayer("Player"));
		//Debug.DrawRay(transform.position, new Vector3(direction.x,direction.y,0), Color.red);
		if (chasing){
			sound.playZombieSound();
			if (prey == null){
				chasing = false;
				return;
			}
			float gap = Vector3.Distance(this.transform.position, prey.transform.position);
			if (gap < chasingRange || overRide){
				//print("chasing " + gap);
				Vector3 target = prey.transform.position;
				Vector3 hunter = this.transform.position;

				//check x
				if (hunter.x < target.x ){
					//move right
					direction.x = 1;
					orientation = DirectionEnumScript.Direction.EAST;
					//print("hunter right");
				}
				else if (hunter.x > target.x){
					//move left
					direction.x  = -1;
					orientation = DirectionEnumScript.Direction.WEST;
					//print("hunter left");
					
				}
				else{
					//stay still
					direction.x = 0;	
					//print("hunter stay x");
					
				}

				//check y
				if (hunter.y < target.y ){
					//move up
					direction.y = 1;
					orientation = DirectionEnumScript.Direction.NORTH;
					//print("hunter up");
					
				}
				else if (hunter.y > target.y){
					//move down
					direction.y = -1;
					orientation = DirectionEnumScript.Direction.SOUTH;
					
				}
				else{
					//stay still
					direction.y = 0;
					///print("hunter stay y");
					
				}
			}
			else{
				//print("lost");
				chasing = false;
			}
		}
		else if(rayCast){
			prey = rayCast.transform.gameObject;
			chasing = true;
			sound.playZombieSound();
			//print("raycasting");
		}
		else{
			//if not in range
			//print("chilling");

			counter++;
			chasing = false;
			//if we have moved for 120ms(2s)
			if (counter > travelDistance || move) {
				//we get a random number to decide our direction of movement
				//print("**** changing dir");
				sound.playZombieSound();
				int number = Random.Range (0, 3);
				travelDistance = Random.Range(120,1200);
				//we move up
				switch(number){
					//we move up
					case 0:
						direction = new Vector2(0,1);
						orientation = DirectionEnumScript.Direction.NORTH;
						break;
					//we move down
					case 1:
						direction = new Vector2(0,-1);
						orientation = DirectionEnumScript.Direction.SOUTH;
						break;
					//we move right
					case 2:
						direction = new Vector2(1,0);
						orientation = DirectionEnumScript.Direction.EAST;
						break;
					//we move left
					case  3:
						direction = new Vector2(-1,0);
						orientation = DirectionEnumScript.Direction.WEST;
						break;
					default:
						direction = new Vector2(0,1);
						orientation = DirectionEnumScript.Direction.NORTH;
						break;

				}


				move = false;
				counter = 0;
			}


		}

		if(orientation == DirectionEnumScript.Direction.NORTH){
			if(srender.sprite != up){
				srender.sprite = up;
			}
		}
		else if (orientation == DirectionEnumScript.Direction.SOUTH){
			if(srender.sprite != down){
				srender.sprite = down;
			}
		}
		else if (orientation == DirectionEnumScript.Direction.EAST){
			if(srender.sprite != right){
				srender.sprite = right;
			}
		}
		else if (orientation == DirectionEnumScript.Direction.WEST) {
			if(srender.sprite != left){
				srender.sprite = left;
			}
		}

		Vector3 movement = new Vector3 (speed.x * direction.x, speed.y * direction.y, 0);
		
		movement *= Time.deltaTime;
		
		transform.Translate (movement);


	}
}
