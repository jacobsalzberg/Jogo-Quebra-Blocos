using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseColider : MonoBehaviour {

    private LevelManager levelManager;

    private void Awake()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger" + collision.name);
        levelManager.LoadLevel("Lose Screen" );

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }


}
