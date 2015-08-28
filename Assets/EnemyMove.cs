using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {

	public float Duration = 1;
	int _maposX;
	int _maposY;
	
	// Use this for initialization
	void Start () {
		MoveToNextTarget();
	}	
	
	IEnumerator MoveToNextTarget(int x, int y)
	{
		float time = 0;
		Vector3 direction = ((new Vector3(x, y)) - transform.position) / Duration;
		
		while(time < Duration) {
			yield return new WaitForEndOfFrame(); 
			
			transform.Translate(direction * Time.deltaTime);
			time += Time.deltaTime;
		}
		
		SetPosition(x, y);
		
		MoveToNextTarget();
	}
	
	void MoveToNextTarget()
	{
		int nextX = _maposX;
		int nextY = _maposY;

		bool success = MapManager.Current.DoNextMove(ref nextX, ref nextY);
		
		if( success ) {
			StartCoroutine( MoveToNextTarget(nextX, nextY) );			
		}
		else
		{
			Debug.Log("EnemyMove:MoveToNextTarget() -> DestroyObject");
			DestroyObject(gameObject, .5f);
		}
	}
	
	public void SetPosition(int x, int y)
	{
		transform.localPosition = new Vector3(x, y, 0);
		_maposX = x;
		_maposY = y;
	}
}
