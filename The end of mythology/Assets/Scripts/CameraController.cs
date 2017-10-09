using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // Use this for initialization
    public GameObject player;
    private GameObject Map;
    private Camera cam;
    //private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        //offset = transform.position - player.transform.position;
        DontDestroyOnLoad(transform.gameObject);
		Map = GameObject.Find("Map");
        cam = Camera.main;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        Vector3 position= player.transform.position;
        position.z = -10;
                  
        var sprite = Map.GetComponent<SpriteRenderer>();
        float xMax = Map.transform.position.x + sprite.bounds.size.x / 2;
        float yMax = Map.transform.position.y + sprite.bounds.size.y / 2;
        
        if (Mathf.Abs(position.x) > xMax - (cam.orthographicSize*cam.aspect))
        {
            if(Mathf.Sign(position.x) == -1){
                position.x = (xMax - (cam.orthographicSize * cam.aspect))*-1;
            }
            else
            {
                position.x = xMax - (cam.orthographicSize * cam.aspect);
            }
            
        }
        if (Mathf.Abs(position.y) > yMax - (cam.orthographicSize))
        {
            if (Mathf.Sign(position.y) == -1)
            {
                position.y = (yMax - (cam.orthographicSize))*-1;
            }
            else
            {
                position.y = yMax - (cam.orthographicSize);
            }
           
        }
        transform.position = position;
    }
}