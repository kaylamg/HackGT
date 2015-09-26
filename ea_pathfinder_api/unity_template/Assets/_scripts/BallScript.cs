using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public GameObject [] balls;
	//the 0 index will be the top, 1 will be the right, etc.
	public GameObject [] ballOpenings;


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

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "wall") {
			Destroy(gameObject);
		}
	}




}
