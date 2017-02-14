using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddleModule;
    private bool startClicked = false;
    private Vector3 paddleToBallPos;

	// Use this for initialization
	void Start () {
        paddleModule = GameObject.FindObjectOfType<Paddle>();
        paddleToBallPos = this.transform.position - paddleModule.transform.position;
        
    }
	
	// Update is called once per frame
	void Update () {

        if (!startClicked)
        {
            this.transform.position = paddleModule.transform.position + paddleToBallPos;
            if (Input.GetMouseButtonDown(0))
            {
                startClicked = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-4f, 4f), 4f);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(-0.3f, 0.3f), 0f);
        if (startClicked)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
