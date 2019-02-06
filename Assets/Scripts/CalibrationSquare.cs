using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationSquare : MonoBehaviour{

    float currCountdownValue;
    private CalibrationController calibrationController;
    private float lifespan = 0f;
    void Start()
    {
        calibrationController = FindObjectOfType<CalibrationController>();
        lifespan = 3f;
        calibrationController.lifespan = this.lifespan;
        //Debug.Log(new AccuracyCalculator(3, 30, 14).Accuracy());
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("trigger");
            StartCoroutine(StartCountdown(lifespan));
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopAllCoroutines();
            calibrationController.slider.value = 0;

        }

    }

    public IEnumerator StartCountdown(float countdownValue)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            //Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);


            currCountdownValue--;
            calibrationController.timeInSquare += 1f;
            Debug.Log("time in square: " + calibrationController.timeInSquare);
            calibrationController.slider.value += 1 / lifespan;
            //Debug.Log(calibrationController.slider.value);
            

            if (currCountdownValue <= 0)
            {
                Destroy(gameObject);
                calibrationController.squareActive = false;
            }
        }
    }

}
