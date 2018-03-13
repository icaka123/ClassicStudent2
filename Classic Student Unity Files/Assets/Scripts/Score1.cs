using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("CScore", 0); //Зануляване на запазения резултат при отиване в Homescreen
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
