using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	public float maxLife;
	public float life;
	public float speed;

	// Use this for initialization
	void Start () {
		life = maxLife;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void takeDamage(float damage){
		life -= damage;
		if (life <= 0)
			Destroy (this.gameObject);
	}
}
