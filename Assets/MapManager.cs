using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {

	public static MapManager Current;

	public int[,] Map;

	public bool DoNextMove(ref int x, ref int y)
	{		
		if((x > 0) && Map[x-1,y] == 1) {
			x = x - 1;
			return true;
		}
		
		if((y < Map.GetLength(1)-1) && Map[x,y+1] == 1) {
			y = y + 1;
			return true;
		}	
			
		return false;
	}	
		
	int[,] _initialMap = {
		{0,0,0,0,0,0,0,0},
		{0,0,0,0,1,1,1,1},
		{0,0,0,0,1,0,0,0},
		{0,0,0,0,1,0,0,0},
		{1,1,1,1,1,0,0,0},
		{0,0,0,0,0,0,0,0}
		};
	
	void Awake() {
		Current = this;
		Map = _initialMap;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
