using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreHelper : MonoBehaviour {
	//public int Score { get; set;}
	int _score;
	public int Score
	{
		get{return _score;}
		set{_score = value;}
	}
	public Text score;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + Score;
	}

}
	


