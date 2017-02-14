using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    public float minPaddlePos;
    public float maxPaddlePos;
    
    private Ball ball;
    //public float paddleSpeed;
    //public Button left;
    //public Button right;

    // Use this for initialization
    void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay)
        {
            moveWithMouse();
        }
        else
            autoPlaying();
    }

    void autoPlaying()
    {
        float ballPos = ball.transform.position.x;
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0);
        paddlePos.x = Mathf.Clamp(ballPos, minPaddlePos, maxPaddlePos);
        this.transform.position = paddlePos;
    }

    void moveWithMouse()
    {
        float mousePos = Input.mousePosition.x / Screen.width * 9f;
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0);
        paddlePos.x = Mathf.Clamp(mousePos, minPaddlePos, maxPaddlePos);
        this.transform.position = paddlePos;
    }
    /*public void moveLeft()
    {
            Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0);
            paddlePos.x -= paddlePos.x * paddleSpeed;
            this.transform.position = paddlePos;
            Debug.Log("clicked!");
    }
    public void moveRight()
    {
        Debug.Log("lolz");
    }*/
}
