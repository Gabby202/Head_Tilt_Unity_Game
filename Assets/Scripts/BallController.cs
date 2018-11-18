using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	private Rigidbody2D rb;
	public float speed = 10;

    // Vector3 movement;
	// Gaze gaze;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		// gaze = FindObjectOfType<Gaze>();
	}

	public void MoveBasedOnHead(float h)
	{
		Vector3 direction = new Vector3(h, 0f, 0f);
		rb.AddForce(direction * speed);
	}



	// Update is called once per frame
	void Update () {
		// Debug.Log(gaze.gazeDataObject.head.ToString());
		// // uses direct translation of head tilt, and * by 1000 to move rb
		// if(gaze.gazeDataObject.head > 0.1f || gaze.gazeDataObject.head < -0.1f) {
		// 	movement  = new Vector3(-gaze.gazeDataObject.head, 0.0f, 0.0f) * speed * Time.deltaTime;
		// } else {
		// 	movement = new Vector3(0f,0f,0f) * speed * Time.deltaTime;
		// }

		// //rb = RigidBody2D
		// rb.MovePosition(movement * 1000f);

	}


}
