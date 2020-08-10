using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public Animator animator;
    public AudioSource creash;   
    [HideInInspector]public bool gameover;
    public GameObject restart,Nextlevel1;
    public GameObject image;
    public Text Gameovertext, Collected,creashtext, Collected1, creashtext1;
    public GameObject Youwin;
    string scenename;
  [HideInInspector] public  int collect=0;
    [HideInInspector] public int crashpoint;
    // Start is called before the first frame update
    void Start()
    {
        Gameovertext.enabled = false;
        restart.SetActive(false);
        Youwin.SetActive( false);
       
    }

    // Update is called once per frame
    void Update()
    {
        creashtext.text = crashpoint.ToString();
        Collected.text = collect.ToString();
        creashtext1.text = crashpoint.ToString();
        Collected1.text = collect.ToString();
        scenename = SceneManager.GetActiveScene().name;
        if (collect >= 20&& crashpoint>=30)
        {
            Youwin.SetActive( true);
            gameover = true;
            image.SetActive(true);

            Nextlevel1.SetActive(true);
        }
        
    }
    public void Nextlevel()
    {
        StartCoroutine(Levelload(SceneManager.GetActiveScene().buildIndex + 1));
    }
    IEnumerator Levelload(int levelindex)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelindex);
    }
    public void Gameover()
    {
      
        Gameovertext.enabled = true;
        gameover = true;
        restart.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(scenename,LoadSceneMode.Single);
    }
   public  void Sound()
    {
        creash.Play();
    }
}
