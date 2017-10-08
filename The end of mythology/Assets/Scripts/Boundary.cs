using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {

	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D other) {
        Destroy(other.gameObject);
	}
}
