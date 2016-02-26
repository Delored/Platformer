using UnityEngine;
using System.Collections;

public class DeathFly : MonoBehaviour {
	public GameObject mario;
	void OnTriggerEnter2D(Collider2D dFly)
	{
		if(dFly.gameObject.tag == "Player")
		{
			StartCoroutine (waier (dFly.gameObject));
		}
	}

	IEnumerator waier(GameObject hero)
	{
		hero.SetActive (false);
		yield return new WaitForSeconds(0.5f);
		Camera.main.GetComponent<PlayerHelper>().Lifes--;
		hero.gameObject.transform.position = Camera.main.GetComponent<PlayerHelper>().Checkpoint;
		hero.SetActive (true);
		//Application.LoadLevel(Application.loadedLevel);
	}


		
		


}
