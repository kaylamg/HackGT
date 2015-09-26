﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BladeCast;


public class PlayerScript : MonoBehaviour {

	public GameObject [] controllers;

	public bool inCollision = false;

	private int ctlrNum;

	// Use this for initialization
	void Start () {

		BCMessenger.Instance.RegisterListener ("position", 0, this.gameObject, "positionHandler");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void positionHandler (ControllerMessage msg){
		if (inCollision == true) {
			StartCoroutine(newDirectionDelay());
		}

		ctlrNum = msg.ControllerSource;

		float x = float.Parse (msg.Payload.GetField ("x-coordinate").ToString ());
		float y = float.Parse (msg.Payload.GetField ("y-coordinate").ToString());

		Vector3 newPos = Camera.main.ViewportToWorldPoint(new Vector3 (x, 1- y, -1));
		Debug.Log (newPos);

		newPos.z = -1;
		//newPos.y = -newPos.y;

		controllers [ctlrNum - 1].transform.position = newPos;
		Debug.Log ("X POSITION: " + x);
		Debug.Log ("Y POSITION: " + y);
	}


	IEnumerator newDirectionDelay() {
		print(Time.time);
		yield return new WaitForSeconds(2);
		print(Time.time);
		inCollision = false;
	}

	

}
