using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] enemy,enemy1;
    public  float spawnrate = 2f;
        public float BigCountDown;
    public bool sp;
    GameManager gamemanager;
    private void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(spawn());
    }
    private void LateUpdate()
    {
        if (spawnrate <= 0.8)
        {
          
            sp = true;
        }

    }
    IEnumerator spawn()
    {
        yield return new WaitForSeconds(3f);
        while (! gamemanager.gameover)
        {
         
            int RandomEnemy = Random.Range(0, enemy.Length);
            int RandomEnemy1 = Random.Range(0, enemy1.Length);
            transform.Rotate(Vector3.right*50*Time.deltaTime);
            Vector2 spawnpos = new Vector2(Random.Range(30f, 40f), Random.Range(-9f, 5f));
            Vector2 spawnpos1 = new Vector2(Random.Range(30f, 40f), Random.Range(-9f, 5f));

            Instantiate(enemy[RandomEnemy], spawnpos, Quaternion.identity);
            Instantiate(enemy1[RandomEnemy1], spawnpos1, Quaternion.identity);
            yield return new WaitForSeconds(spawnrate);
            if (true)
            {
                BigCountDown += 1;
                if (sp==false)
                {
                    if (BigCountDown == 5)
                    {
                        spawnrate -= .2f;
                        BigCountDown = 0f;
                    }
                }
            }
        }
    }
}
