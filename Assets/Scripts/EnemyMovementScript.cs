using UnityEngine;
using System.Collections;

/**
 * this class handles the movement and AI elements for the enemies
 */
public class EnemyMovementScript : MonoBehaviour {

	//*directional variables

	//speed at which enemies move
	public Vector2 speed = new Vector2 (3, 3);
	//the direction the enemy is going in
	public Vector2 direction = new Vector2 (0,0);
	//direction enum for direction, north as default
	public DirectionEnumScript.Direction orientation = DirectionEnumScript.Direction.NORTH;
	//counter used to determine when to change position, default = 120, meaning we change position at start
	private int counter = 120;


	//*other variables

	//the damage the enemy does
	public int damage = 20;

	//*hunting variables

	//boolean to dertermine if we are chasing a player
	public bool chasing = false;
	//the range at which players are detected infront of the enemy
	public float detectionRange = 30f;
	//the range at which players are chased, if this range is surpassed, the enemy 'looses' the player
	public float chasingRange = 6.5f;
	//the distance we are traveling for before changing direction, this is randomly assigned below, default now at 120 so we change direction on start
	private int travelDistance = 120;
	//if we need to force a change of direction due to a collision
	public bool move = false;
	//boolean used to override hunting when chasing a player that has shot the enemy
	public bool overRide = false;

	//*sprite variables

	//the sprites that need to be set in unity (NOTE NOTE NOTE) for the sprite changes based on direction
	public Sprite left;
	public Sprite right;
	public Sprite up;
	public Sprite down;

	//sprite rendered for the sprite changed mentioned above
	private SpriteRenderer srender;

	//*game object variables

	//player 1 object
	private GameObject player1;
	//player 2 object
	private GameObject player2;
	//prey, the player being chased by this enemy
	public GameObject prey;
	//scripts to access sound script
	public GameObject scripts;
	//sound object to play sounds
	private SoundScript sound;
	

	//called on start
	void Start(){
		sound = scripts.GetComponent<SoundScript>();//init
		srender = this.gameObject.GetComponent<SpriteRenderer>();//init
	}


	// Update is called once per frame
	void Update () {
		//we ray cast ahead of the enemy with the set distance to see if the enemy has a player in its FOV, we only detect objects in the player layer
		var rayCast = Physics2D.Raycast(this.transform.position, direction, detectionRange, 1 << LayerMask.NameToLayer("Player"));
		//uncommented, but nice to have for debug purposes, draws a ray cast infront of the enemy to show its directional movement
		//Debug.DrawRay(transform.position, new Vector3(direction.x,direction.y,0), Color.red);

		//if we are chasing
		if (chasing){
			sound.playZombieSound();//play sound
			//if we have no prey to chase
			if (prey == null){
				chasing = false;//set chasing to false, should not have been here if we had no prey (happens if player is being chased and gets killed)
				return;//we end 
			}
			//if we have a prey to chase

			//we get the distance between the enemy and the prey we are chasing
			float gap = Vector3.Distance(this.transform.position, prey.transform.position);
			//if we are close enough or over ride
			if (gap < chasingRange || overRide){
				//we get the position of the prey and hunter
				Vector3 target = prey.transform.position;
				Vector3 hunter = this.transform.position;

				//we check bot axis based on the positions to determine in which direction our enemy has to move

				//check x, 
				if (hunter.x < target.x ){//target is on the right
					//move right
					direction.x = 1;
					orientation = DirectionEnumScript.Direction.EAST;
				}
				else if (hunter.x > target.x){//target is on the left
					//move left
					direction.x  = -1;
					orientation = DirectionEnumScript.Direction.WEST;
				}
				else{//we do not need to move left/right
					//stay still
					direction.x = 0;	
				}

				//check y
				if (hunter.y < target.y ){//target is above 
					//move up
					direction.y = 1;
					orientation = DirectionEnumScript.Direction.NORTH;
				}
				else if (hunter.y > target.y){//target is below
					//move down
					direction.y = -1;
					orientation = DirectionEnumScript.Direction.SOUTH;
				}
				else{//do not need to move up/down
					//stay still
					direction.y = 0;
				}
			}
			//if we are not close enough anymore, ie lost the player
			else{
				chasing = false;//set false so we come back next time we follow right branch
			}
		}
		//if we are not chasing, but found something in out raycast
		else if(rayCast){
			prey = rayCast.transform.gameObject;//assign player to hunt
			chasing = true;//set value true
			//sound.playZombieSound();//play sound
		}
		//if we are not chasing and cant see a player
		else{
			//increment to see if we have travelled far enough
			counter++;
			chasing = false;//just to be sure
			//if we have moved for traveldistance or need to be forced to move
			if (counter > travelDistance || move) {

				//we get a random number to decide our direction of movement
				int number = Random.Range (0, 3);//new direction of movement
				travelDistance = Random.Range(120,1200);//new travel distance
				//we move up
				switch(number){
					//we move up
					case 0:
						direction = new Vector2(0,1);//set the direction
						orientation = DirectionEnumScript.Direction.NORTH;//set the directional enum
						break;
					//we move down
					case 1:
						direction = new Vector2(0,-1);//set the direction
						orientation = DirectionEnumScript.Direction.SOUTH;//set the directional enum
						break;
					//we move right
					case 2:
						direction = new Vector2(1,0);//set the direction
						orientation = DirectionEnumScript.Direction.EAST;//set the directional enum
						break;
					//we move left
					case  3:
						direction = new Vector2(-1,0);//set the direction
						orientation = DirectionEnumScript.Direction.WEST;//set the directional enum
						break;
					default://default
						direction = new Vector2(0,1);
						orientation = DirectionEnumScript.Direction.NORTH;
						break;

				}
				move = false;//set force move false
				counter = 0;//reset counter
			}
		}


		// we now need to set the sprite according to the direction we are moving in
		//each if statement checks for a specific direction and then sets the sprite accordingly if the sprite has not been set yet
		if(orientation == DirectionEnumScript.Direction.NORTH){
			if(srender.sprite != up){
				srender.sprite = up;
				sound.playZombieSound();//play sound
			}
		}
		else if (orientation == DirectionEnumScript.Direction.SOUTH){
			if(srender.sprite != down){
				srender.sprite = down;
				sound.playZombieSound();//play sound
			}
		}
		else if (orientation == DirectionEnumScript.Direction.EAST){
			if(srender.sprite != right){
				srender.sprite = right;
				sound.playZombieSound();//play sound
			}
		}
		else if (orientation == DirectionEnumScript.Direction.WEST) {
			if(srender.sprite != left){
				srender.sprite = left;
				sound.playZombieSound();//play sound
			}
		}
		//we make a new vector for the movement of where our object should be in relation to the direction, and its new position it will attain by moving with its speed
		Vector3 movement = new Vector3 (speed.x * direction.x, speed.y * direction.y, 0);
		//we need to change this new position with repect to delta time
		movement *= Time.deltaTime;
		//we update the objects position accordinly
		transform.Translate (movement);


	}
}
