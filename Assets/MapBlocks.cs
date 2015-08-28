using UnityEngine;
using System.Collections.Generic;

public class MapBlocks : MonoBehaviour {

	public int Width = 8;
	public int Height = 8;
	public GameObject BlockPrefab;
	public List<GameObject> BlockList;
	
	List<GameObject> _blocks;
	
	// Use this for initialization
	void Start () {
		var map = MapManager.Current.Map;
		
		Width = map.GetLength(0);
		Height = map.GetLength(1);
				
		float centerX = (Width - 1)/2.0f;
		float centerY = (Height - 1)/2.0f;

		_blocks = new List<GameObject>();
		
		for(int i=0; i<Width; i++) {
			for(int j=0; j<Height; j++) {
				
				var type = map[i,j];
				var position = new Vector3(i, j, 0);
				var block = Instantiate(BlockList[type], position, Quaternion.identity) as GameObject;
				
				block.transform.SetParent(this.transform);
				
				_blocks.Add(block);
			}
		}
		
		// Camera
		Camera.main.transform.position = new Vector3(centerX, centerY, -10);
		
		// EnemyHQ
		//Instantiate(EnemyHQ, )
		var enemyCreator = GameObject.FindGameObjectWithTag("Respawn").GetComponent<EnemyCreator>();
		enemyCreator.SetMapPosition(4,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
