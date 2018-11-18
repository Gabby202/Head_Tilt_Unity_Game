using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Threading;

public class Gaze : MonoBehaviour
{
    private float tiltThreshold = 0.1f;
    private BallController ballController;
    private float movementHorizontal;
    public GazeData gazeDataObject = new GazeData();
    void Start()
    {
        gazeDataObject.head = -1;
        StartCoroutine(GetText());
    }

    public IEnumerator GetText()
    {
        while(true)
        {
           yield return new WaitForSeconds(0.05f);
            using (UnityWebRequest www = UnityWebRequest.Get("http://localhost:8080/fetchData"))
            {
                yield return www.SendWebRequest();

                if (www.isNetworkError || www.isHttpError)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    string jsonDataReceived =  www.downloadHandler.text;
                    /*
                    // Show results as text
                    //Debug.Log(www.downloadHandler.text);
                    string sTimmmed =  s.Trim( new char[] { '{', '}', ':', 'h', 'e', 'a', 'd', '"' } );
                    float h = float.Parse(sTimmmed);
                    Debug.Log(Time.time + " '" + s + "', as float = " + h);
                    */
                    GazeData gazeDataObject2 = JsonUtility.FromJson<GazeData>(jsonDataReceived);
                    //if empty obj, use previous
                    if(null != gazeDataObject2){
                        gazeDataObject = gazeDataObject2;
                    }
                    // Debug.Log("head: " + GetHeadTiltValue());
                    // Debug.Log(Time.time + ", " + gazeDataObject);
                    // textX.text = gazeDataObject.ToString();
                    
                    
                    ballController = FindObjectOfType<BallController>();
                    Debug.Log("Head tilt value: " + gazeDataObject.head);
                    // Debug.Log("Tilting left: " + myGazeGetter.IsTiltingLeft() + "\nTilting Right: " + myGazeGetter.IsTiltingRight());
                    movementHorizontal = 0;
                    if(IsTiltingLeft()) 
                    {
                        // Debug.Log("left");
                        movementHorizontal = -1;
                    } else if(IsTiltingRight()) 
                    {
                        // Debug.Log("right");
                        movementHorizontal = 1;
                    }
                    ballController.MoveBasedOnHead(movementHorizontal);
                }
            }
        }
    }

    public bool IsTiltingLeft()
    {
        return this.gazeDataObject.head > tiltThreshold;
    }

    public bool IsTiltingRight()
    {
        return this.gazeDataObject.head < tiltThreshold;
    }

    public float GetHeadTiltValue() 
    { 
        return this.gazeDataObject.head;
    }
}
