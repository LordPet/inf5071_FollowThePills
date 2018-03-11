using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillsPickup : MonoBehaviour {

	public int value;
	public bool afficherMessage;

	// Use this for initialization
	void Start () {
		afficherMessage = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
 
	private void OnTriggerEnter(Collider other){
	
		if (other.tag == "Player") {
			FindObjectOfType<GameManager> ().AddPills (value);
			Destroy (gameObject);
		}

		if (gameObject.tag== "Finish") {
				
			Application.LoadLevel("Menu");
		
		}


	}



}
