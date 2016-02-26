using UnityEngine;
using System.Collections;

public class MonsterStandart : MonoBehaviour {

	public GameObject monster;
	int monsteSpeed = 3;
	private Vector2[] dist = new Vector2[2];
	Vector2 _startPosition;
	int endPoint = 0;
	bool isAllife = true;
	private bool monsterFace = true;
    ///////////////////////////
	public bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.25f;
    public LayerMask whatIsGround;
    public bool isFacingRight = true;
	Vector2 _mon; 
	

	
	void Start () {
		_startPosition = transform.position;
		dist[0] = new Vector2((_startPosition.x - 1),_startPosition.y);
		dist[1] = new Vector2((_startPosition.x + 1),_startPosition.y);
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
	
	}
	
	// Update is called once per frame
	void Update () {
		move ();
		////if (Vector2.Distance(transform.position,dist[endPoint]) > 0.1f)
		//if (Vector2.Distance(transform.position,new Vector2(dist[endPoint].x,transform.position.y)) > 0.1f)
		//{
		////transform.position = Vector2.MoveTowards(transform.position, dist[endPoint],Time.deltaTime);
		//transform.position = Vector2.MoveTowards(transform.position, new Vector2(dist[endPoint].x, transform.position.y),Time.deltaTime);
		//}
		//else
		//{
		//	endPoint--;
		//	if (endPoint < 0)
		//	{
		//		endPoint = dist.Length - 1;
		//		Flip();
		//	}
		//	else
		//	{
		//		Flip();
		//	}
		//}
	} 
	void FixedUpdate()
	{
		
	}

	void OnTriggerEnter2D(Collider2D head)
	{
		if (head.gameObject.tag == "Player")
		{
			Destroy(monster);
		}
	}

	void OnCollisionEnter2D(Collision2D enemy)
	{
		if (enemy.gameObject.tag == "Player")
		{
			if (isAllife == true)
			{
				Camera.main.GetComponent<PlayerHelper>().Lifes--;
				isAllife = false;
				StartCoroutine (DelayM(enemy.gameObject));
				//Spawn(enemy.gameObject);
			}
			//else if(enemy.gameObject.name == "Platform_4")
			else if(enemy.gameObject.tag == "Player")
			{
				Destroy(monster);
			}
		}
	}






	void Spawn(GameObject hero)
	{
		//hero = (GameObject)Instantiate (Resources.Load ("Mario"));
		hero.gameObject.transform.position = Camera.main.GetComponent<PlayerHelper>().Checkpoint;
		hero.SetActive (true);
		isAllife = true;
	}

	private void Flip()
	{
		monsterFace = !monsterFace;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	IEnumerator DelayM(GameObject hero) {
		hero.SetActive (false);
		yield return new WaitForSeconds(0.5f);
		Spawn (hero.gameObject);
		Debug.Log("After Waiting 2 Seconds");
	}

	public void move()
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		if (grounded && monsterFace) 
		{
			transform.position = Vector2.MoveTowards(transform.position, transform.position + transform.right * -1, Time.deltaTime);

		}
		if (grounded && !monsterFace) {
			
			transform.position = Vector2.MoveTowards (transform.position, transform.position + transform.right, Time.deltaTime);
		} 
		else if (!grounded) 
		{
			Flip ();
		}

	}


		


    

}

