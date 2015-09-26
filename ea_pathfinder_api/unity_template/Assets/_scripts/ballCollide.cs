using UnityEngine;
using System.Collections;

public class ballCollide : MonoBehaviour {

	public GameObject playerControl;
	//cube 0 will be the top right cube for player 1, 1 will be bottom left, 2 & 3 will be for controller 2, etc.
	public GameObject[] hitCubes;

	public float ballSpeed = 0.5f;
	//1 will mean right, 2 down, 3 left, 4 up, 0 not moving
	public int ballDirection = 2;

	public bool startGame = false;

	// Use this for initialization
	void Start () {

		//GetComponent<MeshRenderer> ().enabled = false;
		playerControl = GameObject.Find ("PlayerScript");
	
	}
	
	// Update is called once per frame
	void Update () {


		//if (startGame == true) {
			GetComponent<MeshRenderer> ().enabled = true;
			if (ballDirection == 1) {
				transform.localPosition += transform.right * ballSpeed * Time.deltaTime;
			} else if (ballDirection == 2) {
				transform.localPosition += -transform.up * ballSpeed * Time.deltaTime;
			} else if (ballDirection == 3) {
				transform.localPosition += -transform.right * ballSpeed * Time.deltaTime;
			} else if (ballDirection == 4) {
				transform.localPosition += transform.up * ballSpeed * Time.deltaTime;
			} else if (ballDirection == 0) {
				transform.localPosition += transform.up * 0 * Time.deltaTime;
			}
		//}

	}

	
	void OnTriggerEnter(Collider other) {
		Debug.Log ("************* entered the trigger");
		if (other.tag == "wall") {
			Debug.Log ("**** I hit the wall");
			Destroy (gameObject);

		} else if (other.tag == "Pipe1") {
			Debug.Log ("**** I have hit pipe ONE!!");

			//check that the ball is validly hitting the pipe, if no, nothing happens
			if ((ballDirection == 3 && (hitCubes [0].transform.position.y - 0.3f <= transform.position.y && transform.position.y <= hitCubes [0].transform.position.y + 0.3f)) || (ballDirection == 4 && (hitCubes [1].transform.position.x - 0.3f <= transform.position.x && transform.position.x <= hitCubes [1].transform.position.x + 0.3f))) {

				//Debug.Log ("HIT CUBES Left: " + (hitCubes [1].transform.position.x - 0.1f) + "X POSITION: " + transform.position.x + "RIGHT POS: " + (hitCubes [1].transform.position.x + 0.1f));

				//pipe needs freezes by calling player script and setting collision true
				playerControl.GetComponent<PlayerScript> ().inCollision = true;


				//ball needs to disappear to "go through" pipe
				GetComponent<MeshRenderer> ().enabled = false;
				StartCoroutine (newDirectionPipeOneDelay ());
				//ball needs to reappear in a new place, going a new direction
			}

		} else if (other.tag == "Pipe2") {
			Debug.Log ("**** I entered pipe TWO!!");

			//check that the ball is validly hitting the pipe, if no, nothing happens
			if ((ballDirection == 1 && (hitCubes [2].transform.position.y - 0.3f <= transform.position.y && transform.position.y <= hitCubes [2].transform.position.y + 0.3f)) || (ballDirection == 4 && (hitCubes [3].transform.position.x - 0.3f <= transform.position.x && transform.position.x <= hitCubes [3].transform.position.x + 0.3f))) {
				
				//Debug.Log ("HIT CUBES Left: " + (hitCubes [1].transform.position.x - 0.1f) + "X POSITION: " + transform.position.x + "RIGHT POS: " + (hitCubes [1].transform.position.x + 0.1f));
				
				//pipe needs freezes by calling player script and setting collision true
				playerControl.GetComponent<PlayerScript> ().inCollision = true;
				
				
				//ball needs to disappear to "go through" pipe
				GetComponent<MeshRenderer> ().enabled = false;
				StartCoroutine (newDirectionPipeTwoDelay ());
				//ball needs to reappear in a new place, going a new direction
			}

		} else if (other.tag == "Pipe3") {
			Debug.Log ("**** I entered pipe THREE!!");

			//check that the ball is validly hitting the pipe, if no, nothing happens
			if ((ballDirection == 3 && (hitCubes [5].transform.position.y - 0.3f <= transform.position.y && transform.position.y <= hitCubes [5].transform.position.y + 0.3f)) || (ballDirection == 2 && (hitCubes [4].transform.position.x - 0.3f <= transform.position.x && transform.position.x <= hitCubes [4].transform.position.x + 0.3f))) {

				
				//pipe needs freezes by calling player script and setting collision true
				playerControl.GetComponent<PlayerScript> ().inCollision = true;
				
				
				//ball needs to disappear to "go through" pipe
				GetComponent<MeshRenderer> ().enabled = false;
				StartCoroutine (newDirectionPipeThreeDelay ());
				//ball needs to reappear in a new place, going a new direction
			}

		} else if (other.tag == "Pipe4") {
			Debug.Log ("**** I entered pipe FOUR!!");

			//check that the ball is validly hitting the pipe, if no, nothing happens
			if ((ballDirection == 1 && (hitCubes [7].transform.position.y - 0.3f <= transform.position.y && transform.position.y <= hitCubes [7].transform.position.y + 0.3f)) || (ballDirection == 2 && (hitCubes [6].transform.position.x - 0.3f <= transform.position.x && transform.position.x <= hitCubes [6].transform.position.x + 0.3f))) {
				
				
				//pipe needs freezes by calling player script and setting collision true
				playerControl.GetComponent<PlayerScript> ().inCollision = true;
				
				
				//ball needs to disappear to "go through" pipe
				GetComponent<MeshRenderer> ().enabled = false;
				StartCoroutine (newDirectionPipeFourDelay ());
				//ball needs to reappear in a new place, going a new direction
			}
		} else if (other.tag == "Goal1") {
			Debug.Log ("GOOOOOOAL");
			Destroy(gameObject);
		}


	}

	IEnumerator newDirectionPipeOneDelay() {

		int oldBallDirection = ballDirection;
		Debug.Log (oldBallDirection);

		ballDirection = 0;
		print(Time.time);
		yield return new WaitForSeconds(2);
		print(Time.time);
		GetComponent<MeshRenderer>().enabled = true;

		//if ball was moving to the left
		if (oldBallDirection == 3){
			transform.position = new Vector3(transform.position.x - 1.2f, transform.position.y - 1.2f, transform.position.z);
			ballDirection = 2;
		}

		//if ball was moving up
		if (oldBallDirection == 4){
			transform.position = new Vector3(transform.position.x + 1.2f, transform.position.y + 1.2f, transform.position.z);
			ballDirection = 1;
		}
	}


	IEnumerator newDirectionPipeTwoDelay() {
		
		int oldBallDirection = ballDirection;
		Debug.Log (oldBallDirection);
		
		ballDirection = 0;
		print(Time.time);
		yield return new WaitForSeconds(2);
		print(Time.time);
		GetComponent<MeshRenderer>().enabled = true;
		
		//if ball was moving to the left
		if (oldBallDirection == 1){
			transform.position = new Vector3(transform.position.x + 1.2f, transform.position.y - 1.2f, transform.position.z);
			ballDirection = 2;
		}
		
		//if ball was moving up
		if (oldBallDirection == 4){
			transform.position = new Vector3(transform.position.x - 1.2f, transform.position.y + 1.2f, transform.position.z);
			ballDirection = 3;
		}
	}

	IEnumerator newDirectionPipeThreeDelay() {
		
		int oldBallDirection = ballDirection;
		Debug.Log (oldBallDirection);
		
		ballDirection = 0;
		print(Time.time);
		yield return new WaitForSeconds(2);
		print(Time.time);
		GetComponent<MeshRenderer>().enabled = true;
		
		//if ball was moving to the left
		if (oldBallDirection == 3){
			transform.position = new Vector3(transform.position.x - 1.2f, transform.position.y + 1.2f, transform.position.z);
			ballDirection = 4;
		}
		
		//if ball was moving up
		if (oldBallDirection == 2){
			transform.position = new Vector3(transform.position.x + 1.2f, transform.position.y - 1.2f, transform.position.z);
			ballDirection = 1;
		}
	}

	IEnumerator newDirectionPipeFourDelay() {
		
		int oldBallDirection = ballDirection;
		Debug.Log (oldBallDirection);
		
		ballDirection = 0;
		print(Time.time);
		yield return new WaitForSeconds(2);
		print(Time.time);
		GetComponent<MeshRenderer>().enabled = true;
		
		//if ball was moving to the left
		if (oldBallDirection == 1){
			transform.position = new Vector3(transform.position.x + 1.2f, transform.position.y + 1.2f, transform.position.z);
			ballDirection = 4;
		}
		
		//if ball was moving up
		if (oldBallDirection == 2){
			transform.position = new Vector3(transform.position.x - 1.2f, transform.position.y - 1.2f, transform.position.z);
			ballDirection = 3;
		}
	}
	
	
}
