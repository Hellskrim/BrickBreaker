using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour {

    public AudioClip crack;
    private int maxHits;
    private int timesHit;
    public Sprite[] hitSprites;
    private LevelManager changeLevel;
    private bool isBreakable;
    public GameObject smoke;

    public static int brickCount = 0;


	// Use this for initialization
	void Start () {
        changeLevel = GameObject.FindObjectOfType<LevelManager>();
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            brickCount++;
            Debug.Log(brickCount);
        }

        timesHit = 0;
	}
	
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable) handleHits();

    }
    void handleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            AudioSource.PlayClipAtPoint(crack, transform.position, 0.1f);
            Destroy(gameObject);
            brickCount--;
            Debug.Log(brickCount);
            GameObject smokePuff = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
            smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
        }
        else loadSprite();

        if (brickCount <= 0) changeLevel.brickDestroyed();
    }

    void loadSprite()
    {
        int spriteIndex = timesHit -1;
        if (hitSprites[spriteIndex] != null)
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        else Debug.Log("Brick sprite's missing...");
    }
}
