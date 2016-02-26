using UnityEngine;
using System.Collections;

public class checkpoint : MonoBehaviour {


	void Start () {
		//Camera.main.GetComponent<PlayerHelper>().Checkpoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnTriggerEnter2D(Collider2D check)
	{
		Camera.main.GetComponent<PlayerHelper>().Checkpoint = transform.position;
	}
}
