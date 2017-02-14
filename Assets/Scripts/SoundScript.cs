using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundScript : MonoBehaviour {

    static SoundScript music = null;
	// Use this for initialization
	void Awake () {
        if (music == null)
        {
            music = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
	}
    void Start()
    {

    }
}
