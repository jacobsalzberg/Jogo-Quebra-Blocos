using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseColider : MonoBehaviour {

    public LevelManager levelManager; //puxa o levelmanager ja criado

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Trigger" + collision.name);
        levelManager.LoadLevel("Win Screen" );

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }


}
