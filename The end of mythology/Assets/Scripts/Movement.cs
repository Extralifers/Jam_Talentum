using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	private BoxCollider2D playerCollider;
	private Rigidbody2D rb;


	private float timeToDash = 0;
    public CharacterParameters parameters;
	void Awake(){
        DontDestroyOnLoad(transform.gameObject);
        rb = GetComponent<Rigidbody2D> ();
		playerCollider = GetComponent<BoxCollider2D> ();
		if (playerCollider == null) {
			Debug.LogError ("There is no BoxCollider Attached to the player!");
		}
		if (rb == null) {
			Debug.LogError ("There is no RigidBody Attached to the player!");
		}
        
	}
	// Use this for initialization
	void Start () {
        parameters = GetComponent<CharacterParameters>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
	
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal,moveVertical);
		rb.velocity = movement * parameters.speed;

		if (Input.GetButtonDown ("Jump") && Time.time > timeToDash) {
			timeToDash = Time.time + 1 / parameters.dashRate;
			rb.AddForce (movement * parameters.dashMovement);
		}

	}
    void OnTriggerEnter2D(Collider2D colider)
    {
        Proyectil pr=colider.gameObject.GetComponent<Proyectil>();
        if (pr != null)
        {
            parameters.quitarVida(pr.damage);
            Destroy(colider.gameObject);
        }
    }
}
