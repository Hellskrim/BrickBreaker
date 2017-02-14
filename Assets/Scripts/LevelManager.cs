using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    
    public void LoadLevel(string name)
    {
        GetHit.brickCount = 0;
        SceneManager.LoadScene(name);
    }
    public void LoadNextLevel()
    {
        GetHit.brickCount = 0;
#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel(Application.loadedLevel + 1);
#pragma warning restore CS0618 // Type or member is obsolete
    }
    public void brickDestroyed()
    {
        if(GetHit.brickCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
