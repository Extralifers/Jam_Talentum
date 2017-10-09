using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YggdrasylAI : MonoBehaviour {

    private Boss bossParams;
    private int fase;
    private GameObject player;


    //Fase 1
    private float timeToFireBolt = 0;

    public GameObject boltSpawners;
    public GameObject bolt;
    public float boltFireRate;
    


    void Awake()
    {
        bossParams = GetComponent<Boss>();

        player = GameObject.FindGameObjectWithTag("Player");
        if(player == null)
        {
            Debug.LogError("Is the player dead? Because we dont find it");
        }
    }

    void Start()
    {
        fase = 1;
    }


    void Update()
    {
        switch (fase)
        {

            case 1:
                BoltShoot();
                break;

            case 2:
                break;

        }

        //if (bossParams.life / bossParams.maxLife < 0.66 && bossParams.life / bossParams.maxLife > 0.33)
        //{
        //    fase = 2;
        //}
        if (bossParams.life / bossParams.maxLife < 0.33)
        {
            fase = 2;
        }

    }



    void BoltShoot()
    {
        if (Time.time > timeToFireBolt)
        {
            timeToFireBolt = Time.time + 1 / boltFireRate;
            int child = Random.Range(0, 2);
            Instantiate(bolt, boltSpawners.transform.GetChild(child).transform.position, boltSpawners.transform.GetChild(child).transform.rotation);

        }

    }
}
