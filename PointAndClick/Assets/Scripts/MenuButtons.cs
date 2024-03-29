using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public void StartTrigger()
    {
        Animator.SetTrigger("Fade");
    }

    public void StartButton()
    {
        Delay();
        SceneManager.LoadScene("Forest1");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
    }
    
}
