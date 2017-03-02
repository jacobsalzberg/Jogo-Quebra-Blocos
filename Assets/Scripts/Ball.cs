using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private Rigidbody2D ballRigidBody2D;
    private bool hasStarted = false;
    //VERSAO QUE EU FIZ DO SOM DA BOLA public static AudioSource bounceBall;
    private AudioSource bounceBall;

    // Use this for initialization
    void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>(); //nao precisa usar o editor!!!
        paddleToBallVector = this.transform.position - paddle.transform.position;
        ballRigidBody2D = GetComponent<Rigidbody2D>();
        //VERSAO QUE EU FIZ DO SOM DA BOLA bounceBall = GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update() {
        if (!hasStarted)
        {
            //Lock the ball relative to the paddle.
            this.transform.position = paddle.transform.position + paddleToBallVector;

            //Wait for a mouse press to Launch the ball.
            if (Input.GetMouseButtonDown(0))
            {
                print("mouse clicked, ball launched");
                hasStarted = true;
                this.ballRigidBody2D.velocity = new Vector2(100f, 500f);
            }
        }
        }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2 (Random.Range(0f,155f), Random.Range(0f,155f));
        print(tweak);
        
        if (hasStarted)
        {
            bounceBall = GetComponent<AudioSource>();
            bounceBall.Play();
            this.ballRigidBody2D.velocity += tweak;
        }
    }
}

