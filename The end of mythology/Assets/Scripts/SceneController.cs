﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void changeScene(string name)
    {
        Application.LoadLevel(name);

    }
}
