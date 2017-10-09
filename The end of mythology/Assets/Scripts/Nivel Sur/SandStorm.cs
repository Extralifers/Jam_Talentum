using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandStorm : MonoBehaviour {

	private Rigidbody2D rb;
	public float speed;

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
		if (rb == null) {
			Debug.LogError ("RigidBody doesnt found");
		}
	}
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {

		rb.AddForce(transform.up * speed);

	}

	void OnTriggerEnter2D (Collider2D coll){
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.GetComponent<CharacterParameters> ().quitarVida (1);
		}
	}
}