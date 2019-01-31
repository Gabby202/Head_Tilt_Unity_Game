using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController3D : MonoBehaviour {

    private Rigidbody rb;
    public float speed = 10;
    public Vector3 playerMovement;
    private float turnForce = 100;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void MoveBasedOnHeadBinary(float h)
    {
        Vector3 direction = new Vector3(h, 0f, 0f);
        rb.AddForce(direction * speed);
    }

    public void MoveBasedOnKeyboard(float h)
    {
        Vector3 direction = new Vector3(h, 0f, 0f);
        rb.AddForce(direction * speed);
    }

    public void StopBall()
    {
        rb.velocity = Vector3.zero;
    }

    public void MoveBasedOnHeadRange(float h)
    {
        // uses direct translation of head tilt, and * by 1000 to move rb
        //if (h > 0.05f || h < -0.05f)
        //{
        //    playerMovement = new Vector3(-h, 0.0f, 0.0f) * speed * Time.deltaTime;
        //    Teleport(h);
        //}
        //else
        //{
        //    playerMovement = new Vector3(0f, 0f, 0f) * speed * Time.deltaTime;
        //}
        Vector3 direction = new Vector3(h, 0f, 0f);
        rb.AddForce(direction * speed);

        //rb.MovePosition(playerMovement * 1000f);
        // transform.Translate((target.position - transform.position) * Time.deltaTime * speed);
    }

    private void Teleport(float x)
    {
        x = -x * 200;
        //print("x = " + x);
        float y = transform.position.y;
        float z = transform.position.z;
        float oldX = transform.position.x;

        x = Mathf.Lerp(oldX, x, 0.1f);

        Vector3 newPos = new Vector3(x, y, z);

        transform.position = newPos;
    }


    // Update is called once per frame
    void Update () {
        rb.AddForce(0, 0, speed);
	}
}
