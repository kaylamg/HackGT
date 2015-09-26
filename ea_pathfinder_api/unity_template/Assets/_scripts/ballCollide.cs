using UnityEngine;
using System.Collections;

public class ballCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}

	
	void OnTriggerEnter(Collider other) {
		Debug.Log ("************* entered the trigger");
		if (other.tag == "wall") {
			Destroy (gameObject);
		}
	}

}
