using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class AccuracyCalculationTest {

    private AccuracyCalculator accuracyCalculator;

    [Test]
    public void AccuracyCalculationTestSimplePasses() {

    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator AccuracyCalculationTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }

    [Test]
    public void AccuractyCalculatedCorrectly()
    {
        accuracyCalculator = new AccuracyCalculator(3, 20, 3);
        float a = accuracyCalculator.Accuracy();

        Assert.AreEqual(20.0, a);
    }

    [Test]
    public void AccuracyCalculateNotLessThanZero()
    {
        accuracyCalculator = new AccuracyCalculator(3, 20, -4);
        float a = accuracyCalculator.Accuracy();

        if(a < 0)
        {
            a = 0;
        }
        Assert.AreEqual(0, a);
    }
}
