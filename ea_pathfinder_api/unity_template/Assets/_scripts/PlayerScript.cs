using UnityEngine;
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
		//Debug.Log (float.Parse(msg.Payload.GetField ("x-coordinate").ToString ()));
		float x = float.Parse (msg.Payload.GetField ("x-coordinate").ToString ()) * 17;
		float y = -(float.Parse (msg.Payload.GetField ("y-coordinate").ToString()) * 9) + 9;
		//Debug.Log (controllers [ctlrNum - 1].transform.position.z);
		//Vector3 newPos = (x, y, (controllers [ctlrNum - 1].transform.position.z));
		//Debug.Log (newPos);
		controllers [ctlrNum - 1].transform.localPosition = new Vector3 (x, y, 0);
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
