using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {

	public int playerLevel = 0;

	public GameObject ballCollideScript;

	public GameObject [] ballArray;

	//array of gae objects with walls and obstacles


	// Use this for initialization
	void Start () {

		ballCollideScript = GameObject.Find ("ballCollide");

		//ask players if they are ready to start

		switch (playerLevel) {
		case (0):
			//ballArray [0].transform.position = new Vector3(Screen.width / 2, Screen.height/2, ballArray [0].transform.position.z);
			//ballCollideScript.GetComponent<ballCollide> ().ballSpeed = 2f;
			//ballCollideScript.GetComponent<ballCollide> ().ballDirection = 3;
			//ballCollideScript.GetComponent<ballCollide> ().startGame = true;
			break;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
