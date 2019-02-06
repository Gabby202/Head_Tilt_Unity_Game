using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController3D : MonoBehaviour {

	private Gaze myGazeGetter;
	private BallController3D ballController;
	private float movementHorizontal;
	public int configuration = 2;
	//public GameObject prefab;
	// Use this for initialization
	void Start () {
		myGazeGetter = FindObjectOfType<Gaze>();
		ballController = FindObjectOfType<BallController3D>();
        //every 20th of a second
        SetConfiguration(this.configuration);

	}
	private void SetConfiguration(int configuration)
    {
        switch (configuration)
        {
            case 0:
                InvokeRepeating("BallMoverBinary", 0, 0.0125f);
                break;
            case 1:
                InvokeRepeating("BallMoverRange", 0, 0.0125f);
                break;
            case 2:
                InvokeRepeating("BallMoverKeyboard", 0, 0.0125f);
                break;
            default:
                InvokeRepeating("BallMoverBinary", 0, 0.0125f);
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
        
		//Debug.Log("Head tilt value: " + myGazeGetter.gazeDataObject);
		movementHorizontal = myGazeGetter.GetHeadTiltValue();
		ballController.MoveBasedOnHeadRange(movementHorizontal);
	}

    public void BallMoverKeyboard()
    {
        if(Input.GetKey(KeyCode.A))
        {
            movementHorizontal = -1;
            ballController.MoveBasedOnKeyboard(movementHorizontal);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementHorizontal = 1;
            ballController.MoveBasedOnKeyboard(movementHorizontal);
        }
        //else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        //{
        //    ballController.StopBall();
        //}
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if (this.configuration == 0 || this.configuration == 1)
            {
                this.configuration++;
            }
            else
            {
                this.configuration = 0;
            }
            this.SetConfiguration(configuration);
            Debug.Log("Configuration Changed to CONFIG: " + this.configuration );
        }
    }

}
