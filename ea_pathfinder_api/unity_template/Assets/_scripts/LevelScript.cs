using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using BladeCast;
using UnityEngine.Audio;

public class LevelScript : MonoBehaviour {

	//audio stuff
	public AudioClip goalSound;
	AudioSource audio;
	
	public int playerLevel;
	public GameObject endGameTextPanel;
	public GameObject levelUpPanel;

	public GameObject ballCollideScript;

	public GameObject ballPrefab;

	private int playerReadyCount = 3; //0;

	public GameObject ULP;
	public GameObject URP;
	public GameObject LLP;
	public GameObject LRP;

	public GameObject OrangeGoal;

	//first 2 small vert, 3rd horiz
	public GameObject[] walls;

	public int lives;
	public int currentBall;

	public GameObject [] livesArray;

	//array of gae objects with walls and obstacles
	

	// Use this for initialization
	void Start () {

		BCMessenger.Instance.RegisterListener ("start", 0, this.gameObject, "startHandler");

		ballCollideScript = GameObject.Find ("ballMoveScript");
		audio = GetComponent<AudioSource>();

	}

	void playersReadyInitializeGame (){
			lives = 5;
			for (int i = 0; i < lives; i++) {
				livesArray [i].SetActive (true);
			}
			playerLevel = 1; //0
			setupLevel ();
			restartGame ();
	}


	void startHandler (ControllerMessage msg){
		int ctlrNum = msg.ControllerSource;
		playerReadyCount ++; 

		if (playerReadyCount == 4) {
			playersReadyInitializeGame();
		}
	}


	// Update is called once per frame
	void Update () {

	
	}

	public void win () {
		audio.PlayOneShot(goalSound, 0.7F);
		currentBall++;
		restartGame ();
		
	}

	public void lose() {
		lives--;
		livesArray[lives].SetActive(false);
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
				GameObject ball = (GameObject) Instantiate(ballPrefab, transform.position = new Vector3(0, 3, -1), Quaternion.identity);
				ball.GetComponent<ballCollide>().ballDirection = 1;
				ball.GetComponent<ballCollide>().ballSpeed = 2;
				ball.GetComponent<ballCollide>().hitCubes[0] = ULP;
				ball.GetComponent<ballCollide>().hitCubes[1] = URP;
				ball.GetComponent<ballCollide>().hitCubes[2] = LLP;
				ball.GetComponent<ballCollide>().hitCubes[3] = LRP;
				break;
			case(1):
				ball = (GameObject) Instantiate(ballPrefab, transform.position = new Vector3(0, 0, -1), Quaternion.identity);
				ball.GetComponent<ballCollide>().ballDirection = 3;
				ball.GetComponent<ballCollide>().ballSpeed = 2;
				ball.GetComponent<ballCollide>().hitCubes[0] = ULP;
				ball.GetComponent<ballCollide>().hitCubes[1] = URP;
				ball.GetComponent<ballCollide>().hitCubes[2] = LLP;
				ball.GetComponent<ballCollide>().hitCubes[3] = LRP;
				break;
			case(2):
				ball = (GameObject) Instantiate(ballPrefab, transform.position = new Vector3(-6.5f, 4.34f, -1), Quaternion.identity);
				ball.GetComponent<ballCollide>().ballDirection = 2;
				ball.GetComponent<ballCollide>().ballSpeed = 2;
				ball.GetComponent<ballCollide>().hitCubes[0] = ULP;
				ball.GetComponent<ballCollide>().hitCubes[1] = URP;
				ball.GetComponent<ballCollide>().hitCubes[2] = LLP;
				ball.GetComponent<ballCollide>().hitCubes[3] = LRP;
				break;
			case(3):
				ball = (GameObject) Instantiate(ballPrefab, transform.position = new Vector3(6, -4.28f, -1), Quaternion.identity);
				ball.GetComponent<ballCollide>().ballDirection = 4;
				ball.GetComponent<ballCollide>().ballSpeed = 2;
				ball.GetComponent<ballCollide>().hitCubes[0] = ULP;
				ball.GetComponent<ballCollide>().hitCubes[1] = URP;
				ball.GetComponent<ballCollide>().hitCubes[2] = LLP;
				ball.GetComponent<ballCollide>().hitCubes[3] = LRP;
				break;
			case(4):
				increaseLevel();
				break;
			}
			break;

		case(1):
			switch (currentBall){
			case (0):
				GameObject ball = (GameObject) Instantiate(ballPrefab, transform.position = new Vector3(-7.05f, -4.36f, -1), Quaternion.identity);
				ball.GetComponent<ballCollide>().ballDirection = 4;
				ball.GetComponent<ballCollide>().ballSpeed = 2;
				ball.GetComponent<ballCollide>().hitCubes[0] = ULP;
				ball.GetComponent<ballCollide>().hitCubes[1] = URP;
				ball.GetComponent<ballCollide>().hitCubes[2] = LLP;
				ball.GetComponent<ballCollide>().hitCubes[3] = LRP;
				break;
			
			case (1):
				ball = (GameObject) Instantiate(ballPrefab, transform.position = new Vector3(4, -0.8f, -1), Quaternion.identity);
				ball.GetComponent<ballCollide>().ballDirection = 2;
				ball.GetComponent<ballCollide>().ballSpeed = 2;
				ball.GetComponent<ballCollide>().hitCubes[0] = ULP;
				ball.GetComponent<ballCollide>().hitCubes[1] = URP;
				ball.GetComponent<ballCollide>().hitCubes[2] = LLP;
				ball.GetComponent<ballCollide>().hitCubes[3] = LRP;
				break;

			case (2):
				ball = (GameObject) Instantiate(ballPrefab, transform.position = new Vector3(8.16f, -2.95f, -1), Quaternion.identity);
				ball.GetComponent<ballCollide>().ballDirection = 4;
				ball.GetComponent<ballCollide>().ballSpeed = 2;
				ball.GetComponent<ballCollide>().hitCubes[0] = ULP;
				ball.GetComponent<ballCollide>().hitCubes[1] = URP;
				ball.GetComponent<ballCollide>().hitCubes[2] = LLP;
				ball.GetComponent<ballCollide>().hitCubes[3] = LRP;
				break;

			case(3):
				ball = (GameObject) Instantiate(ballPrefab, transform.position = new Vector3(-8.37f, 3.6f, -1), Quaternion.identity);
				ball.GetComponent<ballCollide>().ballDirection = 4;
				ball.GetComponent<ballCollide>().ballSpeed = 2;
				ball.GetComponent<ballCollide>().hitCubes[0] = ULP;
				ball.GetComponent<ballCollide>().hitCubes[1] = URP;
				ball.GetComponent<ballCollide>().hitCubes[2] = LLP;
				ball.GetComponent<ballCollide>().hitCubes[3] = LRP;
				break;
			
			case(4):
				increaseLevel();
				break;
			}
			break;

		case (2):
			break;
		}
	}

	//Increase level by 1
	public void increaseLevel() {
		destroyLevel ();
		playerLevel++;
		setupLevel ();
		if (lives < 10) {
			lives ++; 
			for (int i = 0; i < lives; i++) {
				livesArray [i].SetActive (true);
			}
		}
		levelUpPanel.SetActive (true);
		StartCoroutine (levelUpDelay());
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

		case(1):
			Destroy(OrangeGoal);
			Destroy (walls[0]);
			Destroy (walls[1]);
			Destroy (walls[2]);
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
			
			Instantiate (OrangeGoal, transform.position = new Vector3 (-0.16f, -4.55f, -0.52f), Quaternion.identity);
			break;

		case(1):
			Instantiate (ULP, transform.position = new Vector3 (-4, 2, -1), Quaternion.identity);
			Instantiate (URP, transform.position = new Vector3 (4, 2, -1), Quaternion.identity);
			Instantiate (LLP, transform.position = new Vector3 (-4, -3, -1), Quaternion.identity);
			Instantiate (LRP, transform.position = new Vector3 (4, -3, -1), Quaternion.identity);

			Instantiate (OrangeGoal, transform.position = new Vector3 (3.87f, 4.49f, -0.52f), Quaternion.identity);

			Instantiate (walls[0], transform.position = new Vector3 (0.14f, 3.51f, -0.73f), Quaternion.identity);
			Instantiate (walls[1], transform.position = new Vector3 (-4.18f, 0.86f, -0.73f), Quaternion.identity);
			Instantiate (walls[2], transform.position = new Vector3 (4.04f, -0.34f, -0.73f), Quaternion.identity);
			break;

		}
	}

	public void endGame() {
		levelUpPanel.SetActive (false);
		endGameTextPanel.SetActive(true);
		Debug.Log ("You Lost!");
	}

	IEnumerator levelUpDelay() {
		
		print (Time.time);
		yield return new WaitForSeconds (2);
		print (Time.time);
		levelUpPanel.SetActive (false);
	}


}
