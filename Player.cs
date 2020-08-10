using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    Animator Anim;
    public GameObject firepoint,bullet;
    public AudioSource recieveletter,Gunshot;
    public GameObject[] heart; 
   public AudioSource hitsound;
    public int Speed, hit;
   bool stopmove;
   public Rigidbody2D rb;
    GameManager gamemanager;
   
    float nexttime=0, spawntime=0.5f;
   
    private void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
     
        Anim = GetComponent<Animator>();
    }
    void Update()
    {

        float ver = Input.GetAxis("Vertical");
        transform.Translate(Vector3.up * ver * Time.deltaTime * Speed);
        float mouse = Input.GetAxis("Mouse Y");
    // firepoint.transform.Rotate(Vector2.one * Time.deltaTime*100*mouse);
        if (transform.position.y > 4.24 )
        {
            this.gameObject.transform.position = new Vector2(-20, 4.24f);
        }
        if( transform.position.y < -7.4f)
        {
            this.gameObject.transform.position = new Vector2(-20, -7.4f);
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > nexttime)
            {
                nexttime = Time.time + spawntime;
                Anim.SetTrigger("Shoot");
                firring();
                Gunshot.Play();
            }
        }
       
    }
    void firring()
    {
        Instantiate(bullet, firepoint.transform.position,transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.gameObject.tag == "NotCollect")
        {
            hit += 1;
            hitsound.Play();
            switch (hit)
            {
                case 1:
                    heart[0].SetActive(false);
                    break;
                case 2:
                    heart[1].SetActive(false);
                    break;
                case 3:
                    heart[2].SetActive(false);
                    break;
                case 4:
                    heart[3].SetActive(false);
                    break;
                case 5:
                    hit = 0;
                    break;
            }
            if (hit == 4)
            {
                gamemanager.Gameover();
            }
        }
       
        

        if (collision.gameObject.tag == "Collect")
        {
            gamemanager.collect += 1;
            gamemanager.crashpoint -= 1;
            recieveletter.Play();
           
        }
       
    }

}
