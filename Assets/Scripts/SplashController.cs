using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashController : MonoBehaviour
{
    public Animator animator;

    public void Start()
    {
        ShowSplash();
    }

    public void ShowSplash()
    {
        animator.SetBool("hide", false);
        animator.SetBool("show", true);
    }

    public void RemoveSplash()
    {
        animator.SetBool("show", false);
        animator.SetBool("hide", true);
    }
}
