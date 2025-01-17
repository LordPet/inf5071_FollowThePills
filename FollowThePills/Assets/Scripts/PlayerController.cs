﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;
	public float gravityScale;
	public CharacterController controller;
	private Vector3 moveDirection;


	// Use this for initialization
	void Start () {
		
		controller = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		// si je le place dans le if isgrounded j'empêche le player de bouger une fois dans les airs
		//moveDirection = new Vector3(Input.GetAxis("Horizontal")* moveSpeed, moveDirection.y,Input.GetAxis("Vertical") * moveSpeed);
		float yStore = moveDirection.y;
		moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
		moveDirection = moveDirection.normalized * moveSpeed;
		moveDirection.y = yStore;

		if (controller.isGrounded) {
			moveDirection.y = 0f;
			if (Input.GetButtonDown ("Jump")) {	
				moveDirection.y = jumpForce;	
			}
		}
		moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
		controller.Move(moveDirection * Time.deltaTime);
	}
}
