using UnityEngine;
using System.Collections;

public class EnemyCreator : MonoBehaviour {

	public GameObject Enemy;
	
	int MapPositionX = -1;
	int MapPositionY = -1;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(CreateEnemy());
	}
	
	public void SetMapPosition(int x, int y)
	{
		//transform.localPosition = new Vector3(x, y, 0);
		MapPositionX = x;
		MapPositionY = y;		
	}
	
	IEnumerator CreateEnemy()
	{		
		while(true) {
			yield return new WaitForSeconds(1.0f);
			
			var enemy = Instantiate(Enemy);
			enemy.transform.SetParent(this.transform);
			
			var enemyMove = enemy.GetComponent<EnemyMove>();
			enemyMove.SetPosition(MapPositionX, MapPositionY);		
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
