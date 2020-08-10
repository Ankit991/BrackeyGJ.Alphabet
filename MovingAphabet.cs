
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MovingAphabet : MonoBehaviour
{
    public ParticleSystem death;
    GameManager gamemanager;
    public float speed;
    
    private void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void FixedUpdate()
    {
       
      
        if (!gamemanager.gameover)
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
            Destroy(this.gameObject, 6f);

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 pos = transform.position;
      ParticleSystem D=  Instantiate(death, pos, transform.rotation);


        if (gameObject.tag == "Collect")
        {
            
            Destroy(this.gameObject, 0.1f);
       

        }

        if (gameObject.tag == "NotCollect")
            {
          

            D.Play();
                Destroy(this.gameObject);
               

            }
        
    }
}







