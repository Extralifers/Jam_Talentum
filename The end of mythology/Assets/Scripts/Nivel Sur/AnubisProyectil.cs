using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnubisProyectil : MonoBehaviour {

	private GameObject anubis;
	private Vector3 dir;

	void Awake(){
		anubis = GameObject.FindGameObjectWithTag ("Boss");

	}

	// Use this for initialization
	void Start () {
		dir = anubis.GetComponent<Anubis> ().shootingDirection;
		Destroy (this.gameObject, 3);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Translate (dir * Time.deltaTime * anubis.GetComponent<Anubis>().shootingSpeed);
	}

	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.tag == "Player") { 
			coll.gameObject.GetComponent<CharacterParameters> ().quitarVida (1);
			Destroy (this.gameObject);
		}

		if(coll.gameObject.tag == "Enviroment")
			Destroy (this.gameObject);
	}

}