﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private Gaze myGazeGetter;
	private BallController ballController;
	private float movementHorizontal;
	public int configuration = 0;
	// Use this for initialization
	void Start () {
		myGazeGetter = FindObjectOfType<Gaze>();
		ballController = FindObjectOfType<BallController>();
		//every 20th of a second
		switch(configuration)
		{
			case 0: 
			InvokeRepeating("BallMoverBinary", 0,  0.05f);
			break;
			case 1:
			InvokeRepeating("BallMoverRange", 0,  0.05f);
			break;
			default:
			InvokeRepeating("BallMoverBinary", 0,  0.05f);
			break;

		}
	}
	
	public void BallMoverBinary() 
	{
	
		// Debug.Log("Head tilt value: " + myGazeGetter.gazeDataObject.head);
		// Debug.Log("Tilting left: " + myGazeGetter.IsTiltingLeft() + "\nTilting Right: " + myGazeGetter.IsTiltingRight());
		movementHorizontal = 0;
		if(myGazeGetter.IsTiltingLeft()) 
		{
			// Debug.Log("left");
			movementHorizontal = -1;
		} else if(myGazeGetter.IsTiltingRight()) 
		{
			// Debug.Log("right");
			movementHorizontal = 1;

		}
		ballController.MoveBasedOnHeadBinary(movementHorizontal);
	}

	public void BallMoverRange()
	{
		movementHorizontal = myGazeGetter.GetHeadTiltValue();
		ballController.MoveBasedOnHeadRange(movementHorizontal);
	}
}
