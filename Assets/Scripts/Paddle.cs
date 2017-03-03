using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
    
{

    public static bool autoPlay;
    // Use this for initialization
    private Ball ball;


    void Start ()
    {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }
    void AutoPlay()
    {
        /*this.transform.position.y <-- keep the current position*/
        Vector3 paddlePos = new Vector3(20f, this.transform.position.y, -1f);

        //debug--> print(MousePosInBlocks);

        // this.transform.posion.x = MousePosInBlocks;  nao funciona, erro comum
        Vector3 ballPos = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 50, 750);
        this.transform.position = paddlePos; //this is the instance of the paddles (script).. deixa bem claro qual eh
    }
    void MoveWithMouse()
    {
        float MousePosInBlocks;
        /*this.transform.position.y <-- keep the current position*/
        Vector3 paddlePos = new Vector3(20f, this.transform.position.y, -1f);
        MousePosInBlocks = Input.mousePosition.x / Screen.width * 800; // jeito de ficar melhor na tela, com numero de blocos
        //debug--> print(MousePosInBlocks);

        // this.transform.position.x = MousePosInBlocks;  nao funciona, erro comum

        paddlePos.x = Mathf.Clamp(MousePosInBlocks, 50, 750);
        this.transform.position = paddlePos; //this is the instance of the paddles (script).. deixa bem claro qual eh
    }

    public void Toggle_Changed(bool newValue)
    {
        if (autoPlay == newValue)
        {
            autoPlay = false;
        }
        else
        {
            autoPlay = true;
        }
        //print(autoPlay);
        
    }
}
