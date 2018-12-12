using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CalibrationController : MonoBehaviour {

    private GameObject prefab;
    public GameObject square;
    public GameObject rect;
    public Text timerText;
    public float totalTime = 30f;
    private float timer = 0f;
    private float accuracy = 0;
    private GameObject[] rectPositions;
    private float width;
    private float height;
    Vector3 position;
    public bool squareActive = false;
    public bool calibrationFinished = false;
    private int counter;
    public Slider slider;
    public AccuracyCalculator accuracyCalculator;
    public float lifespan = 0;
    public float timeInSquare = 0;


    void Start () {
        timer = totalTime;
        timeInSquare = 0;
        accuracy = 0;
        rectPositions = GameObject.FindGameObjectsWithTag("RectPosition");   
        counter = 0;
        position = new Vector3(0, 0, 0);

    }

    void Update () {

        timer -= Time.deltaTime;
        timerText.text = timer.ToString();
        if(timer < 0)
        {
            PlayerPrefs.SetFloat("accuracy", 0f);
            accuracyCalculator = new AccuracyCalculator(lifespan, totalTime, timeInSquare);
            accuracy = accuracyCalculator.Accuracy();
            PlayerPrefs.SetFloat("accuracy", accuracy);
            SceneManager.LoadScene("CalibrationOver");
        }

        if(!squareActive)
        {
            slider.value = 0;
            SpawnSquare(counter);
            counter++;
        }
    }

    public void SpawnSquare(int screenLocation)
    {
        switch(screenLocation)
        {
            case 0:
                position = GameObject.Find("PortionL").transform.position;
                prefab = square;
                break;
            case 1:
                position = GameObject.Find("PortionR").transform.position;
                prefab = square;
                break;
            case 2:
                position = GameObject.Find("PortionLL").transform.position;
                prefab = square;
                break;
            case 3:
                position = GameObject.Find("PortionRR").transform.position;
                prefab = square;
                break;
            default:
                position = rectPositions[Random.Range(0, 6)].transform.position;
                prefab = rect;
                break;
            //case 4:
            //    Debug.Log("Calibration Finished");
            //    calibrationFinished = true;
            //    break;

        }
        if(!calibrationFinished)
        {
            Instantiate(prefab, position, Quaternion.identity);
            squareActive = true;
        } else
        {
            PlayerPrefs.SetFloat("accuracy", accuracy);
            SceneManager.LoadScene("CalibrationOver");
        }
    }

}
