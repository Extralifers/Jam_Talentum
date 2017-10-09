using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour {

    private float destroyTime = 60F;
    private float dmgTime = 0.25F;

	// Use this for initialization
	void Start () {
        transform.GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, destroyTime * Time.deltaTime);
    }
	
	// Update is called once per frame
	void Update () {

        dmgTime -= Time.deltaTime;
        if (dmgTime <= 0)
        {
            transform.GetComponent<Collider2D>().enabled = true;
        }
        
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<CharacterParameters>().quitarVida(1);
        }
    }
}
