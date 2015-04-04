using UnityEngine;
using System.Collections;

/**
 * This class is a enumeration for directional identifiers (NORTH,SOUTH,EAST,WEST)
 * Most important game objects get such a identifier in order to work on directional sprite changes and movement as well as collision reponses
 */
public class DirectionEnumScript : MonoBehaviour {


	//we make a new enum with its 4 entries
	public enum Direction {NORTH,SOUTH,WEST,EAST};

	//method that gives us the opposite direction based on a sent in direction
	public static Direction getOpposite(Direction dir){
		if (dir == Direction.NORTH){
			return Direction.SOUTH;
		}
		else if (dir == Direction.SOUTH){
			return Direction.NORTH;
		}
		else if (dir == Direction.EAST){
			return Direction.WEST;
		}
		else{
			return Direction.EAST;
		}
	}



}
