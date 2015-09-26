using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {

	public int playerLevel;

	public GameObject ballCollideScript;

	public GameObject ballPrefab;

	//array of gae objects with walls and obstacles
	

	// Use this for initialization
	void Start () {
		playerLevel = 0;
		ballCollideScript = GameObject.Find ("ballMoveScript");


		restartGame ();

		//ask players if they are ready to start

//		switch (playerLevel) {
//		case (0):
			//ballArray [0].transform.position = new Vector3(Screen.width / 2, Screen.height/2, ballArray [0].transform.position.z);
			//ballCollideScript.GetComponent<ballCollide> ().ballSpeed = 2f;
			//ballCollideScript.GetComponent<ballCollide> ().ballDirection = 3;
			//ballCollideScript.GetComponent<ballCollide> ().startGame = true;
//			break;
//		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void win () {
		Debug.Log ("in win!");
		increaseLevel ();
		restartGame ();
	}

	public void lose() {
		restartGame ();
	}

	// Detects the level and sets up the scene etc. 
	public void restartGame () {
		Debug.Log ("playerLevel" + playerLevel);
		switch (playerLevel) {
		case(0):
			GameObject ball = (GameObject) Instantiate(ballPrefab, transform.position = new Vector3(0, 0, 0), Quaternion.identity);
			ball.GetComponent<ballCollide>().ballDirection = 2;
			break;
		case(1):
//			ballCollideScript.GetComponent<ballCollide>().ballDirection = 3;
//			Debug.Log ( ballCollideScript.GetComponent<ballCollide>().ballDirection);


			ball = (GameObject) Instantiate(ballPrefab, transform.position = new Vector3(0, 0, 0), Quaternion.identity);
			ball.GetComponent<ballCollide>().ballDirection = 1;
			Debug.Log ( ball.GetComponent<ballCollide>().ballDirection);
			

			break;
		}

	}

	//Increase level by 1
	public void increaseLevel() {
		playerLevel++;
		Debug.Log ("increasing level!");
	}

	private void level1() {

	}
}
