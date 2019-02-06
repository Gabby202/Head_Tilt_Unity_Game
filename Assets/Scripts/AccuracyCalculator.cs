using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracyCalculator {

    //private float accuracyRatio;
    //private float timer;
    //private float allowanceModifier;
    //private float lifespan;

    //private float lifespan;
    private float totalTime;
    private float allowanceMod;
    public float timeInSquare;

    public AccuracyCalculator(float lifespan, float timer, float timeInSquare)
    {
        this.totalTime = timer;
        //this.lifespan = lifespan;
        this.timeInSquare = timeInSquare;
        this.allowanceMod = 0.75f;
               
        //this.timer = timer;
        //this.lifespan = lifespan;
        //allowanceModifier = timer * 1f;
        //accuracyRatio = 0f;
        //accuracyRatio = (timer + allowanceModifier) / lifespan;
        //accuracyRatio /= 100;
    }

    public float Accuracy()
    {
        return Mathf.Ceil(100 * (timeInSquare / (allowanceMod * totalTime)));
        //return Mathf.Ceil(accuracyRatio * lifespan * 10);
    }
}
