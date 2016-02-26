using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour {

	// Use this for initialization

	public GameObject statBar;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadLevel()
	{
		SceneManager.LoadSceneAsync ("Level_1");
	}
}
