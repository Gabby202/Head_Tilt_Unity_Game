using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public Text accuracyText;

	// Use this for initialization
	void Start () {
        accuracyText.text = "Overall Accruacy: " +  PlayerPrefs.GetFloat("accuracy").ToString() + "%";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
