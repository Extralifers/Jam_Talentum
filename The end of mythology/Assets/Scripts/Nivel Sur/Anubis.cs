using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anubis : MonoBehaviour {

	public Boss bossParameters;
	private int fase;

	private GameObject player;

	//Fase 1
	public GameObject proyectil;
	public GameObject startShooting;
	public Vector3 shootingDirection;
	public int shootingSpeed;
	public float firerate;
	private float timeToFire = 0;
	public AudioSource shootAttackSound;

	//Fase 2
	public GameObject sandStormSpawners;
	public GameObject sandStorm;
	public float sandStormRate;
	private float timeToSandStorm = 0;
	public AudioSource sandStormSound;


	//Fase 3
	public GameObject spawners;
	public GameObject mosca;
	public float flyRate;
	private float timeToPlague = 0;
	private int actualRound = 0;


	void Awake () {
		bossParameters = GetComponent<Boss> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		if (player == null) {
			Debug.LogError ("Is the player dead? Because we dont find it");
		}
	}

	// Use this for initialization
	void Start () {
		if (proyectil == null) {
			Debug.LogError ("There is no proyectile to shoot");
		}
		if (startShooting == null) {
			Debug.LogError ("There is no point to start shooting");
		}
		fase = 1;
	}
	
	// Update is called once per frame
	void Update () {
		switch (fase) {
			
		case 1:
			shootAttack ();
			break;

		case 2:
			shootAttack ();
			SandStormAttack ();
			break;

		case 3:
			shootAttack ();
			SandStormAttack ();
			flyPlague ();
			break;
			
		}

		if (bossParameters.life / bossParameters.maxLife < 0.66 && bossParameters.life / bossParameters.maxLife > 0.33) {
			fase = 2;
		}
		if (bossParameters.life / bossParameters.maxLife < 0.33) {
			fase = 3;
		}
	}

	private void shootAttack(){
		if (Time.time > timeToFire) {
			timeToFire = Time.time + 1 / firerate;
			shootingDirection = player.transform.position - startShooting.transform.position;
			RaycastHit2D hit = Physics2D.Raycast (startShooting.transform.position, shootingDirection);
			if (Mathf.Abs(shootingDirection.x) >= Mathf.Abs(shootingDirection.y)) {
				if(shootingDirection.x<0)
					shootingDirection /= -shootingDirection.x;
				else
					shootingDirection /= shootingDirection.x;
			} else {
				if(shootingDirection.y<0)
					shootingDirection /= -shootingDirection.y;
				else
					shootingDirection /= shootingDirection.y;
			}
			shootAttackSound.Play ();
			Instantiate (proyectil, startShooting.transform.position, startShooting.transform.rotation);
		}
	}

	private void SandStormAttack(){
		if (Time.time > timeToSandStorm) {
			sandStormSound.Play ();
			timeToSandStorm = Time.time + 1 / sandStormRate;
			int child = Random.Range (0, 3);
			Instantiate(sandStorm,sandStormSpawners.transform.GetChild(child).transform.position,sandStormSpawners.transform.GetChild(child).transform.rotation);
		}
	}

	private void flyPlague(){
		if (Time.time > timeToPlague) {
			timeToPlague = Time.time + 1 / flyRate;
			for (int i = 0; i < spawners.transform.childCount; i++) {
				Instantiate (mosca, spawners.transform.GetChild (i).position, spawners.transform.GetChild (i).rotation);
			}
		}
	}
}
