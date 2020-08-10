using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Uimanager : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    public void PlayGame()
    {
     StartCoroutine(Levelload(SceneManager.GetActiveScene().buildIndex + 1));
    }
    public void Quit()
    {
        Application.Quit();
    }
    IEnumerator Levelload(int levelindex)
    {
        animator.SetTrigger("Start");   
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelindex);
    }
}
