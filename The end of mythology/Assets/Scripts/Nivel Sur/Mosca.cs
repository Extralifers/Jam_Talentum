using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosca : MonoBehaviour {

	public float movement;
	public float rateOfMovement;
	private float timeToMove = 0;
	private float fase = 0;

	private Rigidbody2D rb;

	void Awake(){
		rb = GetComponent<Rigidbody2D> ();
		if (rb == null) {
			Debug.Log ("There is no rigidbody attached!");
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		if (Time.time > timeToMove) {
			timeToMove = Time.time + 1 / rateOfMovement;
			if (fase == 1) {
				rb.AddForce(new Vector3 (-1, 0) * movement) ;
				fase++;
			}else if(fase == 2){
				rb.AddForce(new Vector3 (1, 0) * movement);
				fase = 1;
			}else if (fase == 0) {
				rb.AddForce(new Vector3 (1, 0) * (movement/2));
				fase++;
			} 
	
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
			coll.gameObject.GetComponent<CharacterParameters> ().quitarVida (1);
			Destroy (this.gameObject);
		}

		if (coll.gameObject.tag == "Enviroment" || coll.gameObject.tag == "Boss") {
			Destroy (this.gameObject);
		}
	}

}
