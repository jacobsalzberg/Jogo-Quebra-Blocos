using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public static int breakableCount = 0; //avaliable to all other classes, as its public!
    public Sprite[] hitSprites;
    public AudioClip crack;

    private LevelManager levelManager;
    private int timesHit; //propriedades darticulares
    private bool isBreakable;
    public GameObject smoke;

    // Use this for initialization
    void Start()
    {
        isBreakable = (this.tag == "Breakable");
        //keep track of breakable bricks
        if (isBreakable)
        {
            breakableCount++;
           // print(breakableCount);
        }

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, Camera.main.transform.position);
        //VERSAO QUE EU FIZ DO SOM DA BOLA Ball.bounceBall.Play();
        if (isBreakable)
        {
            HandleHits();
        }       
    }

    void HandleHits()
    {
        timesHit++;

        int maxHits = hitSprites.Length + 1; //pega o tamanho do vetor e adiciona 01
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();

            //  print(breakableCount);
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    // TODO Remote this method once we can actually win
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex]!=null)
        {
        this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick Sprite Missing");
        }
    }

    void PuffSmoke()
    {
        smoke = Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
        ParticleSystem.MainModule main = smoke.GetComponent<ParticleSystem>().main;
        main.startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }
}
