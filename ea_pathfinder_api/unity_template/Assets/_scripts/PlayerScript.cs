using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BladeCast;


public class PlayerScript : MonoBehaviour {

	public GameObject [] controllers;

	private int ctlrNum;

	// Use this for initialization
	void Start () {

		BCMessenger.Instance.RegisterListener ("position", 0, this.gameObject, "positionHandler");

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void positionHandler (ControllerMessage msg){
		ctlrNum = msg.ControllerSource;
		float x = int.Parse(msg.Payload.GetField ("x-coordinate").ToString()) * Screen.width;
		float y = int.Parse (msg.Payload.GetField ("y-coordinate").ToString()) * Screen.height;
		Vector3 newPos = new Vector3 (x, y, (controllers [ctlrNum - 1].transform.position.z));
		Debug.Log (newPos);
		//controllers [ctlrNum - 1].transform.position (newPos);
	}


}
