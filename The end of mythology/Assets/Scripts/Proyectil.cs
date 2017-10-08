using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {

    private BoxCollider2D proyectilCollider;
    private Rigidbody2D rb;
    private GameObject player;

    public CharacterParameters parameters;

    void Awake()
    {
    }

    void Start () { 
        proyectilCollider = GetComponent<BoxCollider2D>();
        if (proyectilCollider == null)
        {
            Debug.LogError("There is no BoxCollider Attached to the proyectile!");
        }

        try{
            player = GameObject.FindGameObjectWithTag("Player");
            parameters = player.GetComponent<CharacterParameters>();
        }
        catch
        {
            Debug.LogError("The player is not created yet or is dead");
        }

        rb = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate () {
        rb.AddForce(transform.up * parameters.fireSpeed);
    }

}
