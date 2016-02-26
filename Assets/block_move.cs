using UnityEngine;
using System.Collections;

public class block_move : MonoBehaviour {
	Vector2 _startpoint;
	public Vector2[] _distance = new Vector2[2];
	int speed;
	int _end = 0;

	// Use this for initialization
	void Start () {
		_startpoint = transform.position;
		_distance[0] = new Vector2((_startpoint.x - 1),_startpoint.y);
		_distance[1] = new Vector2((_startpoint.x + 1), _startpoint.y);	
	}
	
	// Update is called once per frame
	void Update () {
		//if (Vector2.Distance(transform.position,dist[endPoint]) > 0.1f)
		if (Vector2.Distance(transform.position,new Vector2(_distance[_end].x,transform.position.y)) > 0.1f)
		{
			//transform.position = Vector2.MoveTowards(transform.position, dist[endPoint],Time.deltaTime);
			transform.position = Vector2.MoveTowards(transform.position, new Vector2(_distance[_end].x, transform.position.y),Time.deltaTime);
		}
		else
		{
			_end--;
			if (_end < 0)
			{
				_end = _distance.Length - 1;
				//Flip();
			}
	}
}
}
