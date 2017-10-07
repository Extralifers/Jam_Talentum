using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {

	// Use this for initialization
    private BoxCollider2D proyectilCollider;
    void Start () { 
        proyectilCollider = GetComponent<BoxCollider2D>();
        if (proyectilCollider == null)
        {
            Debug.LogError("There is no BoxCollider Attached to the proyectile!");
        }
      
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
