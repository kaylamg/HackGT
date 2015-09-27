using UnityEngine;
using System.Collections;

public class ballCollide : MonoBehaviour {

	public GameObject playerControl;

	//cube 0 will be the top right cube for player 1, 1 will be bottom left, 2 & 3 will be for controller 2, etc.
	public GameObject[] hitCubes;

	//public GameObject[] pipes;

	public GameObject levelScript;

	public float ballSpeed = 3f;

	//1 will mean right, 2 down, 3 left, 4 up, 0 not moving
	public int ballDirection;

	public bool startGame = false;

	public bool inCollisionPublic;
	private bool inCollision;

	// Use this for initialization
	void Start () {

		//GetComponent<MeshRenderer> ().enabled = false;
		playerControl = GameObject.Find ("PlayerScript");

		levelScript = GameObject.Find("Level Script");

		hitCubes = new GameObject[4];
		hitCubes [0] = GameObject.Find ("UpperLeftPrefab(Clone)");
		hitCubes [1] = GameObject.Find ("UpperRightPrefab(Clone)");
		hitCubes [2] = GameObject.Find ("LowerLeftPrefab(Clone)");
		hitCubes [3] = GameObject.Find ("LowerRightPrefab(Clone)");
		inCollisionPublic = false;

	
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

		if (inCollision)
			inCollisionPublic = true;

	}

	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "wall") {
			Debug.Log ("**** I hit the wall");
			Destroy (gameObject);

			levelScript.GetComponent<LevelScript>().lose();
				

		} else if (other.tag == "Pipe1") {
			Debug.Log ("**** I have hit pipe ONE!!");

			//check that the ball is validly hitting the pipe, if no, nothing happens
			bool cond1 = (ballDirection == 3);  
			bool cond2 = (transform.position.y <= (hitCubes [0].transform.position.y + 0.5));
			bool cond3 = (transform.position.y >= (hitCubes [0].transform.position.y - 0.5));


			bool cond4 = (ballDirection == 4); 
			bool cond5 = (transform.position.x <= (hitCubes [0].transform.position.x + 0.5));
			bool cond6 = (transform.position.x >= (hitCubes [0].transform.position.x - 0.5));

			if ((cond1 && cond2 && cond3) || (cond4 && cond5 && cond6)) {

				//pipe needs freezes by calling player script and setting collision true

				Debug.Log ("NOW LEAING PIPE ONE ******************");


				//ball needs to disappear to "go through" pipe
				GetComponent<MeshRenderer> ().enabled = false;
				this.enabled = false;

				StartCoroutine (newDirectionPipeOneDelay ());
				//ball needs to reappear in a new place, going a new direction
			}

		} else if (other.tag == "Pipe2") {
			Debug.Log ("**** I entered pipe TWO!!");

			//check that the ball is validly hitting the pipe, if no, nothing happens
			bool cond1 = (ballDirection == 1);  
			bool cond2 = transform.position.y <= (hitCubes[1].transform.position.y + 0.5);
			bool cond3 = transform.position.y >= (hitCubes[1].transform.position.y - 0.5);

			bool cond4 = (ballDirection == 4);  
			bool cond5 = transform.position.x <= (hitCubes[1].transform.position.x + 0.5);
			bool cond6 = transform.position.x >= (hitCubes[1].transform.position.x - 0.5);

			if ((cond1 && cond2 && cond3) || (cond4 && cond5 && cond6)) {
				
				//ball needs to disappear to "go through" pipe
				GetComponent<MeshRenderer> ().enabled = false;
				this.enabled = false;

				StartCoroutine (newDirectionPipeTwoDelay ());
				//ball needs to reappear in a new place, going a new direction
			}

		} else if (other.tag == "Pipe3") {
			Debug.Log ("**** I entered pipe THREE!!");

			//check that the ball is validly hitting the pipe, if no, nothing happens

			bool cond1 = (ballDirection == 3);
			bool cond2 = (transform.position.y <= (hitCubes [2].transform.position.y + 0.5));
			bool cond3 = (transform.position.y >= (hitCubes [2].transform.position.y - 0.5));

			bool cond4 = (ballDirection == 2);
			bool cond5 = (transform.position.x <= (hitCubes [2].transform.position.x + 0.5));
			bool cond6 = (transform.position.x >= (hitCubes [2].transform.position.x - 0.5));


			if ((cond1 && cond2 && cond3) || (cond4 && cond5 && cond6)) {
				
				//ball needs to disappear to "go through" pipe
				GetComponent<MeshRenderer> ().enabled = false;
				this.enabled = false;

				StartCoroutine (newDirectionPipeThreeDelay ());
				//ball needs to reappear in a new place, going a new direction
			}

		} else if (other.tag == "Pipe4") {
			Debug.Log ("**** I entered pipe FOUR!!");

			//check that the ball is validly hitting the pipe, if no, nothing happens

			bool cond1 = (ballDirection == 1);
			bool cond2 = (transform.position.y <= (hitCubes [3].transform.position.y + 0.5));
			bool cond3 = (transform.position.y >= (hitCubes [3].transform.position.y - 0.5));

			
			bool cond4 = (ballDirection == 2);
			bool cond5 = (transform.position.x <= (hitCubes [3].transform.position.x + 0.5));
			bool cond6 = (transform.position.x >= (hitCubes [3].transform.position.x - 0.5));
			
			if ((cond1 && cond2 && cond3)|| (cond4 && cond5 && cond6)) {
				
				
				//ball needs to disappear to "go through" pipe
				GetComponent<MeshRenderer> ().enabled = false;
				this.enabled = false;

				StartCoroutine (newDirectionPipeFourDelay ());
				//ball needs to reappear in a new place, going a new direction

			}

		} else if (other.tag == "Goal1") {
			Debug.Log ("GOOOOOOAL");
			Destroy(gameObject);

			levelScript.GetComponent<LevelScript>().win();
		}
	}

	IEnumerator newDirectionPipeOneDelay() {
		inCollision = true;
		int oldBallDirection = ballDirection;
		Debug.Log (oldBallDirection);

		ballDirection = 0;
		print(Time.time);
		yield return new WaitForSeconds(1);
		Debug.Log ("Collision ends here");
		inCollision = false;
		print(Time.time);
		GetComponent<MeshRenderer>().enabled = true;
		this.enabled = true;

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
		inCollision = true;
		int oldBallDirection = ballDirection;
		Debug.Log (oldBallDirection);
		
		ballDirection = 0;
		print(Time.time);
		yield return new WaitForSeconds(1);
		print(Time.time);
		inCollision = false;
		GetComponent<MeshRenderer>().enabled = true;
		this.enabled = true;
		
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
		inCollision = true;
		
		int oldBallDirection = ballDirection;
		Debug.Log (oldBallDirection);
		
		ballDirection = 0;
		print(Time.time);
		yield return new WaitForSeconds(1);
		print(Time.time);
		GetComponent<MeshRenderer>().enabled = true;
		inCollision = false;
		this.enabled = true;
		
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
		inCollision = true;
		
		int oldBallDirection = ballDirection;
		Debug.Log (oldBallDirection);
		
		ballDirection = 0;
		print(Time.time);
		yield return new WaitForSeconds(1);
		print(Time.time);
		GetComponent<MeshRenderer>().enabled = true;
		inCollision = false;
		this.enabled = true;
		
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
