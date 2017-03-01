using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float MousePosInBlocks;
        /*this.transform.position.y <-- keep the current position*/
        Vector3 paddlePos = new Vector3(this.transform.position.x, this.transform.position.y, -1f);
        MousePosInBlocks = Input.mousePosition.x / Screen.width * 800; // jeito de ficar melhor na tela, com numero de blocos
                                                                       //debug--> print(MousePosInBlocks);

        // this.transform.position.x = MousePosInBlocks;  nao funciona, erro comum

        paddlePos.x = Mathf.Clamp(MousePosInBlocks, 50, 750);
        this.transform.position = paddlePos; //this is the instance of the paddles (script).. deixa bem claro qual eh
        

    }
}
