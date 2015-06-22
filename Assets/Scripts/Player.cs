using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 50f;
	public float maxSpeed = 5;
	public float power = 150f;
	public bool grounded;

	private Rigidbody2D rg2d;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rg2d = gameObject.GetComponent<Rigidbody2D>();
		anim = gameObject.GetComponent<Animator>();
	
	}

	void Update () {
		anim.SetBool ("Grounded", grounded);
		anim.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));

		if (Input.GetAxis ("Horizontal") < -0.1f) 
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}

		if (Input.GetAxis ("Horizontal") > 0.1f) 
		{
			transform.localScale = new Vector3(1, 1, 1);
		}
	}

	void FixedUpdate() {

		float h = Input.GetAxis("Horizontal");
		rg2d.AddForce((Vector2.right * speed) * h); 


		if (rg2d.velocity.x > maxSpeed) 
		{
			rg2d.velocity = new Vector2(maxSpeed, rg2d.velocity.y);
		}
		if (rg2d.velocity.x < -maxSpeed) 
		{
			rg2d.velocity = new Vector2 (-maxSpeed, rg2d.velocity.y);
		}
	}
}
