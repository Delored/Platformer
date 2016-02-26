using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{

    // Use this for initialization
    float move;
    public GameObject Mario;
    float _movespeed = 4f; // скорость передвижения персонажа
    float _jumpPower = 200f; // сила прыжка
    bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.25f;
    public LayerMask whatIsGround;
    private bool isFacingRight = true;
	private Animator anim;
    void Start()
    {
		anim = GetComponent<Animator>();
    }
	GameObject Cmario;

    // Update is called once per frame
    void Update()
    {

     

        //rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);


        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    rigidbody2D.AddForce(Mario.transform.right * 50);
            //Mario.transform.eulerAngles = new Vector2(0, 0);
            //Mario.transform.position += Mario.transform.right * _movespeed * Time.deltaTime;
        
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    Mario.transform.eulerAngles = new Vector2(0, 180);
        //    GetComponent<Animator>().SetBool("Run", true);
        //    Mario.transform.position += Mario.transform.right * _movespeed * Time.deltaTime;
        //}
        //if (grounded && Input.GetButton("Jump"))
        //{
            //GetComponent<Animator>().SetBool("Stay",true);
            //Mario.transform.position += Mario.transform.up * _jumpPower * Time.deltaTime;
            //rigidbody2D.AddForce(new Vector2(0f, _jumpPower));
        //}

        //{
        //    GetComponent<Animator>().SetBool("Stay", true);
        //}
       
        //if (Input.GetKey(KeyCode.U))
        //{
        //    Application.LoadLevel(Application.loadedLevel);
        //}


    }
    void FixedUpdate()
    {
        Moves();
	//	grcheck ();


    }

    private void Moves()
    {
        move = Input.GetAxis("Horizontal");
		anim.SetFloat("speed", Mathf.Abs(move));
		if (move != 0)
		{
//			Debug.Log("Play");
		}
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * _movespeed, GetComponent<Rigidbody2D>().velocity.y);

        if (move > 0 && !isFacingRight)
            Flip();

        else if (move < 0 && isFacingRight)
            Flip();

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (grounded && Input.GetButton("Jump"))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, _jumpPower));
			grounded = false;
        }

        if (Input.GetKey(KeyCode.U))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

		if (Input.GetKey (KeyCode.E)) 
		{
			Cmario = Instantiate(Resources.Load("Prefabs/Mario"), new Vector3(transform.position.x-5, transform.position.y,0), transform.rotation) as GameObject;
		}
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

	void OnCollisionEnter2D(Collision2D movplat)
	{
		if (movplat.transform.tag == "movedPlapform") 
		{
			//Debug.Log ("Chield");
			Mario.transform.parent = movplat.transform;
		}
	}

	void OnCollisionExit2D(Collision2D movplat)
	{
		if (movplat.transform.tag == "movedPlapform") 
		{
			Debug.Log ("Chield");
			Mario.transform.parent = null;
		}
	}


	

	//public void grcheck()
	//{
	//	if (!grounded) 
	//	{
	//		Debug.Log ("Not Grounded");
	//	}
	//}
}
