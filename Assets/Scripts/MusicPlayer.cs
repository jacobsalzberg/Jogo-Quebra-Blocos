﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    private void Awake()
    {
        //Debug.Log("Music player Awake" + GetInstanceID());
        if (instance != null) //if an instance of a musicplayer exists
        {
            Destroy(gameObject);
            // print("Music player self-destructing!!!");
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject); // instance of the music player
        }
    }
    // Use this for initialization
    //void Start () {
        //Debug.Log("Music player Start" + GetInstanceID());
    
            //}
	
	// Update is called once per frame
	void Update () {
		
	}

}
