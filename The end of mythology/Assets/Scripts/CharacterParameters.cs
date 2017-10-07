using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParameters : MonoBehaviour {

    public float maxLife;
    public float life;
    public float damage;
    public float speed;
    public float dashRate;
    public float dashMovement = 10000;
    // Use this for initialization
    void Start () {
        life = maxLife;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void quitarVida(float damage)
    {
        life -= damage;
    }
}
