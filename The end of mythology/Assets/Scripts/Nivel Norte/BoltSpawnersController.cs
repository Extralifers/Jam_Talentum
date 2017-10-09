using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltSpawnersController : MonoBehaviour {

    private Vector3 positionX;
    private Vector3 positionY;
    private float PosRandomizer;

    public GameObject player;

	
	void Start () {
        UpdatePosition();
    }
	

	void LateUpdate () {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        PosRandomizer = Random.Range(-4, 4);
        //Igualar coordenadas del jugador a las de los spawners
        positionX = new Vector3(0, player.transform.position.y + PosRandomizer, 0);
        positionY = new Vector3(player.transform.position.x + PosRandomizer, 0, 0);
        //Cambiar posición de los spawners para que sigan al player
        transform.GetChild(0).transform.position = positionX;
        transform.GetChild(1).transform.position = positionY;
    }
}
