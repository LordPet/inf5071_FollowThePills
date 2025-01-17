﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform target;
	public Transform pivot;
	public Vector3 offset;
	public bool useOffsetValues;
	public float rotateSpeed;
	public float maxViewAngle;
	public float minViewAngle;
	public bool invertY;

	// Use this for initialization
	void Start () {
		if (!useOffsetValues) {
			
			offset = target.position - transform.position;
		}
		pivot.transform.position = target.transform.position;
		pivot.transform.parent = target.transform;	

		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	// late update pour regler le bug de frame, cette function arrive apres les updates.
	void LateUpdate () {

		// trouver le personnage et bouger la camera
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		target.Rotate (0, horizontal, 0);

		// rotate avec le pivot
		float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
		pivot.Rotate (-vertical, 0, 0);
		if (invertY) {
			pivot.Rotate (	vertical, 0, 0);
		} else {
			pivot.Rotate (-vertical, 0, 0);
		}

		// limiter le mouvement de la camera up/down
		if(pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f){
			pivot.rotation = Quaternion.Euler (maxViewAngle,0,0);
		}

		if(pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f + minViewAngle){
			pivot.rotation = Quaternion.Euler (360f + minViewAngle,0,0);
		}

		// bouger la camera avec la position de rotation
		float desiredYAngle = target.eulerAngles.y;
		float desiredXAngle = pivot.eulerAngles.x;

		Quaternion rotation = Quaternion.Euler (desiredXAngle,desiredYAngle, 0);
		transform.position = target.position - (rotation * offset);

		if (transform.position.y < target.position.y) {
			transform.position = new Vector3 (transform.position.x, target.position.y - 0.5f, transform.position.z);
		}


		transform.LookAt (target);	
	}
}
