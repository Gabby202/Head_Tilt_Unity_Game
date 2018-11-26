using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccuracyCalculator {

    private float accuracyRatio;
    private float timer;
    private float allowanceModifier;
    private float lifespan;

    public AccuracyCalculator(float lifespan, float timer)
    {
        this.timer = timer;
        this.lifespan = lifespan;
        allowanceModifier = timer * 1f;
        accuracyRatio = 0f;
        accuracyRatio = (timer + allowanceModifier) / lifespan;
        accuracyRatio /= 100;
    }

    public float Accuracy()
    {
        return Mathf.Ceil(accuracyRatio * lifespan * 10);
    }
}
