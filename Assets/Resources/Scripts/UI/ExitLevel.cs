using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void exitLevel()
	{
		SceneManager.LoadScene ("Menu");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
