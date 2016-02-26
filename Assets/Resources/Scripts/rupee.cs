using UnityEngine;
using System.Collections;

public class rupee : MonoBehaviour {
	public GameObject _rupee;

	void OnTriggerEnter2D(Collider2D trigee)
	{
		if (trigee.gameObject.name == "Mario")
		{
			Destroy(_rupee);
			Camera.main.GetComponent<ScoreHelper>().Score++;
		}
	}

}
