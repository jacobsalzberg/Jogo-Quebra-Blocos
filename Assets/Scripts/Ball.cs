﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Paddle paddle;
    private Vector3 paddleToBallVector;
    private Rigidbody2D ballRigidBody2D;
    private bool hasStarted = false;

    // Use this for initialization
    void Start () {
        paddleToBallVector = this.transform.position - paddle.transform.position;
        ballRigidBody2D = GetComponent<Rigidbody2D>();
		
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
	}

