using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public Animator buttonsAnim;
    public Animator logoAnim;
    public static MainMenuManager instance;
    public float secondsToStart = 0.5f;

    private void Start()
    {
        if (instance == null) instance = this;
        StartCoroutine(StartLogoAnimationAfterSeconds());
    }
    public void StartLogoAnimation()
    {
        logoAnim.SetTrigger("Start");
    }

    public void StartButtonAnimation()
    {
        buttonsAnim.SetTrigger("Start");
    }

    IEnumerator StartLogoAnimationAfterSeconds()
    {
        yield return new WaitForSeconds(secondsToStart);
        StartLogoAnimation();
    }
}
