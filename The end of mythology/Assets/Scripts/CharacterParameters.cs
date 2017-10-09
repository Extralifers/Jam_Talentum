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
    public UIRenderer UIController;
    public float fireRate;
    public float fireSpeed;
    // Use this for initialization
    void Awake()
    {
        life = maxLife;
        UIController = GameObject.Find("UIController").GetComponent<UIRenderer>();
    }
    void Start () {       
        UIController.cambiarVida();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void quitarVida(float damage)
    {
        life -= damage;
        UIController.cambiarVida();
    }
}
