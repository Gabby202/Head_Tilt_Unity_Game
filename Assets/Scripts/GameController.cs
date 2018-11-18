using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private Gaze myGazeGetter;
	private BallController ballController;
	private float movementHorizontal;
	public int configuration = 0;
	public GameObject prefab;
	// Use this for initialization
	void Start () {
		myGazeGetter = FindObjectOfType<Gaze>();
		ballController = FindObjectOfType<BallController>();
		//every 20th of a second
		switch(configuration)
		{
			case 0: 
			InvokeRepeating("BallMoverBinary", 0,  0.0125f);
			break;
			case 1:
			InvokeRepeating("BallMoverRange", 0,  0.0125f);
			break;
			default:
			InvokeRepeating("BallMoverBinary", 0,  0.0125f);
			break;

		}

		InvokeRepeating("BlockSpawner", 0, 2);
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
		// Debug.Log("Head tilt value: " + myGazeGetter.gazeDataObject.head);
		movementHorizontal = myGazeGetter.GetHeadTiltValue();
		ballController.MoveBasedOnHeadRange(movementHorizontal);
	}

	public void BlockSpawner()
	{
		Vector3 position = new Vector3(Random.Range(-80.0f, 80.0f), 60, 0);
        Instantiate(prefab, position, Quaternion.identity);
	}
}
