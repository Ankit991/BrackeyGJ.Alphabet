using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmovement : MonoBehaviour
{
    public ParticleSystem death;
    Rigidbody2D rb;
    GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * 25);

        Destroy(gameObject, 6f);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 pos = transform.position;
       ParticleSystem deathsp= Instantiate(death, pos, Quaternion.identity);
        deathsp.Play();
        gamemanager.Sound();
        gamemanager.crashpoint += 1;
        Destroy(collision.gameObject);
        Destroy(gameObject);

     
    }
}
