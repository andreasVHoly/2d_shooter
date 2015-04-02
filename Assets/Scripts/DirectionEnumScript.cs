using UnityEngine;
using System.Collections;

public class DirectionEnumScript : MonoBehaviour {

	public enum Direction {NORTH,SOUTH,WEST,EAST};


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
