using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {

    private BoxCollider2D proyectilCollider;
    private Rigidbody2D rb;

    public float speed;
    public float damage = 1;

    void Start () { 
        proyectilCollider = GetComponent<BoxCollider2D>();
        if (proyectilCollider == null)
        {
            Debug.LogError("There is no BoxCollider Attached to the proyectile!");
        }

        rb = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate () {
        rb.AddForce(transform.up * speed);
    }

}
