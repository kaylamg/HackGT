using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BladeCast;


public class PlayerScript : MonoBehaviour {

	//public GameObject [] controllers;


	public int ctlrNum;
	private bool currentlyColliding;

	public GameObject ballCollideScript;

	// Use this for initialization
	void Start () {

		BCMessenger.Instance.RegisterListener ("position", 0, this.gameObject, "positionHandler");

		ballCollideScript = GameObject.Find ("ballMoveScript");

//		playerControl.GetComponent<PlayerScript> ().inCollision = false;
		
	
	}
	
	// Update is called once per frame
	void Update () {
	 	bool currentlyColliding = ballCollideScript.GetComponent<ballCollide> ().inCollisionPublic;
		Debug.Log ("Am I currently colliding?" + currentlyColliding);
		if (currentlyColliding)
			Debug.Log ("COLLIDING!");
	
	}

	void positionHandler (ControllerMessage msg){
		
		if (currentlyColliding == true) {
			return;
		} else if (currentlyColliding == false) {

			float x = float.Parse (msg.Payload.GetField ("x-coordinate").ToString ());
			float y = float.Parse (msg.Payload.GetField ("y-coordinate").ToString ());

			Vector3 newPos = Camera.main.ViewportToWorldPoint (new Vector3 (x, 1 - y, -1));
//			Debug.Log (newPos);

			newPos.z = -1;

			if (ctlrNum == msg.ControllerSource) {

				transform.position = newPos;
//				Debug.Log ("X POSITION: " + x);
//				Debug.Log ("Y POSITION: " + y);
			}
		}
	}


//	IEnumerator newDirectionDelay() {
//		yield return new WaitForSeconds(3);
//	}

	
}
