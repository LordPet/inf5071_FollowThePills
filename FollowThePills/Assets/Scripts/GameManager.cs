using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int currentPills;
	public Text pillsText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddPills(int pillsToAdd){
		
		currentPills += pillsToAdd;
		pillsText.text = "Pilules: " + currentPills;
	
	}
}
