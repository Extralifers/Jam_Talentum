using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private BoxCollider2D playerCollider;
    private Rigidbody2D rb;
    private Transform aim;

    private float nextFire = 0;

    private float timeToDash = 0;

    public CharacterParameters parameters;

    public GameObject projectile;
    public GameObject shotSpawners;

    

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        rb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        if (playerCollider == null)
        {
            Debug.LogError("There is no BoxCollider Attached to the player!");
        }
        if (rb == null)
        {
            Debug.LogError("There is no RigidBody Attached to the player!");
        }

        parameters = GetComponent<CharacterParameters>();

    }
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		if ((Input.GetAxis("FireX")!=0 || Input.GetAxis("FireY")!=0) && Time.time > nextFire)
        {
			Shoot();
        }
    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * parameters.speed;

        if (Input.GetButtonDown("Jump") && Time.time > timeToDash)
        {
            timeToDash = Time.time + 1 / parameters.dashRate;
            rb.AddForce(movement * parameters.dashMovement);
        }

    }
    void OnTriggerEnter2D(Collider2D colider)
    {
        /*Proyectil pr=colider.gameObject.GetComponent<Proyectil>();
        if (pr != null)
        {
            parameters.quitarVida(pr.damage);
            Destroy(colider.gameObject);
        }*/
    }

    void Shoot()
    {
        //Aim N
        if (Input.GetAxis("FireY") > 0)
            aim = shotSpawners.transform.GetChild(0).transform;
        //Aim S
        if (Input.GetAxis("FireY") < 0)
            aim = shotSpawners.transform.GetChild(1).transform;
        //Aim E
        if (Input.GetAxis("FireX") > 0)
            aim = shotSpawners.transform.GetChild(2).transform;
        //Aim W
        if (Input.GetAxis("FireX") < 0)
            aim = shotSpawners.transform.GetChild(3).transform;

        //Shoot    
        nextFire = Time.time + 1 / parameters.fireRate;
        Instantiate(projectile, aim.position, aim.rotation);
    }
}
