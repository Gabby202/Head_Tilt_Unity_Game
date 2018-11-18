using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	private Rigidbody2D rb;
	public float speed = 10;
	public Vector3 playerMovement;


	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}

	public void MoveBasedOnHeadBinary(float h)
	{
		Vector3 direction = new Vector3(h, 0f, 0f);
		rb.AddForce(direction * speed);
	}

	public void MoveBasedOnHeadRange(float h)
	{
		// uses direct translation of head tilt, and * by 1000 to move rb
		if(h > 0.05f || h < -0.05f) {
			playerMovement  = new Vector3(-h, 0.0f, 0.0f) * speed * Time.deltaTime;
		} else {
			playerMovement = new Vector3(0f,0f,0f) * speed * Time.deltaTime;
		}

		rb.MovePosition(playerMovement * 1000f);
		// transform.Translate((target.position - transform.position) * Time.deltaTime * speed);

	}


	void Update () {

	}



}
