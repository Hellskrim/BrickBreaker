using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseCollider : MonoBehaviour {

    private LevelManager level;
    void Start()
    {
        level = GameObject.FindObjectOfType<LevelManager>();
        
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {

        level.LoadLevel("Lose Screen");
    }
    /*void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided");
    }*/
}
