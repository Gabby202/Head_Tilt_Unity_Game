using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalibrationSquare : MonoBehaviour{

    float currCountdownValue;
    private float accuracyRatio;
    private float allowanceModifier;
    private CalibrationController calibrationController;
    private float lifespan = 0f;
    void Start()
    {
        calibrationController = FindObjectOfType<CalibrationController>();
        lifespan = 3f;
        allowanceModifier = calibrationController.timer * 0.3f;
        accuracyRatio = 0f;

        accuracyRatio = (calibrationController.timer + allowanceModifier) / lifespan;
        accuracyRatio /= 100;
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
            calibrationController.slider.value += 1 / lifespan;
            //Debug.Log(calibrationController.slider.value);
            calibrationController.accuracy += Mathf.Ceil(accuracyRatio * lifespan * 10);
            Debug.Log(calibrationController.accuracy);
            if (currCountdownValue <= 0)
            {
                Destroy(gameObject);
                calibrationController.squareActive = false;
            }
        }
    }

}
