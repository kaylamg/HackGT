using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour {

	public int playerLevel;
	public GameObject endGameTextPanel;

	public GameObject ballCollideScript;

	public GameObject ballPrefab;

	public GameObject ULP;
	public GameObject URP;
	public GameObject LLP;
	public GameObject LRP;

	public GameObject OrangeGoal;

	public int lives;
	public int currentBall;

	//array of gae objects with walls and obstacles
	

	// Use this for initialization
	void Start () {
		playerLevel = 0;
		lives = 5;
		ballCollideScript = GameObject.Find ("ballMoveScript");
		setupLevel ();
	
		restartGame ();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void win () {
		currentBall++;
		restartGame ();
		
	}

	public void lose() {
		lives--;
		restartGame ();
	}

	// Detects the level and sets up the scene etc. 
	public void restartGame () {
		if (lives <= 0) 
			endGame ();

		switch (playerLevel) {
		
		case(0):
			switch(currentBall) {
			case(0):
				GameObject ball = (GameObject) Instantiate(ballPrefab, transform.position = new Vector3(0, 0, -1), Quaternion.identity);
				ball.GetComponent<ballCollide>().ballDirection = 1;
				break;
			case(1):
				ball = (GameObject) Instantiate(ballPrefab, transform.position = new Vector3(0, 0, -1), Quaternion.identity);
				ball.GetComponent<ballCollide>().ballDirection = 3;
				break;
			case(2):
				ball = (GameObject) Instantiate(ballPrefab, transform.position = new Vector3(-6.5f, 4.34f, -1), Quaternion.identity);
				ball.GetComponent<ballCollide>().ballDirection = 2;
				break;
			case(3):
				ball = (GameObject) Instantiate(ballPrefab, transform.position = new Vector3(6, -4.28f, -1), Quaternion.identity);
				ball.GetComponent<ballCollide>().ballDirection = 4;
				break;
			case(4):
				increaseLevel();
				break;
			}

			break;
		case(1):

			break;

		
		}
	}

	//Increase level by 1
	public void increaseLevel() {
		destroyLevel ();
		playerLevel++;
		setupLevel ();
	}

	public void destroyLevel() {
		Destroy (ULP);
		Destroy (URP);
		Destroy (LLP);
		Destroy (LRP);

		switch (playerLevel) {
		case(0):
			Destroy(OrangeGoal);
			break;
		}

	}

	public void setupLevel() {
		currentBall = 0;

		switch (playerLevel) {
		
		case(0):

			Instantiate (ULP, transform.position = new Vector3 (-4, 2, -1), Quaternion.identity);
			Instantiate (URP, transform.position = new Vector3 (4, 2, -1), Quaternion.identity);
			Instantiate (LLP, transform.position = new Vector3 (-4, -3, -1), Quaternion.identity);
			Instantiate (LRP, transform.position = new Vector3 (4, -3, -1), Quaternion.identity);
			
			Instantiate (OrangeGoal, transform.position = new Vector3 (-0.16f, -4.45f, -0.52f), Quaternion.identity);
			break;

		case(1):
			break;
		}
	}

	public void endGame() {
		endGameTextPanel.SetActive(true);
		Debug.Log ("You Lost!");
	}

}
