using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHelper : MonoBehaviour {
	public GameObject Mario_Hero;
	private int _lifes;
	private Vector2 _checkpoint;
	public GameObject Live;
	public GameObject _gameOver;
	public Vector2 Checkpoint
	{
		get{return _checkpoint ;}
		set{_checkpoint = value ;}

	}
	public int Lifes
	{
		get {return _lifes ;}
		set {_lifes = value	;}
	}
	public Text life;
	// Use this for initialization
	void Start () {
		Lifes = 1;
	
	}
	
	// Update is called once per frame
	void Update () {
		life.text = Lifes.ToString ();
		if (Lifes < 0) 
		{
			Live.SetActive (false);
			_gameOver.SetActive (true);
		}
	}
}
