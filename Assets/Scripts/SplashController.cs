using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashController : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer rendere;

    public void Start()
    {
        ShowSplash();
    }

    public void ShowSplash()
    {
        rendere.gameObject.SetActive(true);
        animator.SetBool("hide", false);
        animator.SetBool("show", true);
    }

    public void RemoveSplash()
    {
        rendere.gameObject.SetActive(true);
        animator.SetBool("show", false);
        animator.SetBool("hide", true);
    }


}
