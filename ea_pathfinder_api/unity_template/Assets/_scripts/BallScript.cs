using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public GameObject [] balls;

	private int ballSpeed = 5;
	private bool startGame = false;

	// Use this for initialization
	void Start () {

		//ask user if they want to start the game
		startGame = true;
	
	}
	
	// Update is called once per frame
	void Update () {

		if (startGame == true) {
			balls [1].transform.localPosition += transform.right * ballSpeed * Time.deltaTime;
		}
	
	}


}
