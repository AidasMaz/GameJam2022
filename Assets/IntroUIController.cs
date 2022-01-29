using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroUIController : MonoBehaviour
{
    [Header("Intro objects")]
    [SerializeField] private Image FadeImage;
    [Space]
    [SerializeField] private Image IntroImage;

    [Header("Variables")]
    [SerializeField] private float fadeTime;
    [SerializeField] private float showTime;

    public bool finishedIntro;

    public void Initialize()
    {
        finishedIntro = false;

        FadeImage.gameObject.SetActive(true);
        IntroImage.gameObject.SetActive(true);

        StartCoroutine(HandleIntroAnimations());
    }

    IEnumerator HandleIntroAnimations()
    {
        FadeImage.CrossFadeAlpha(0.0f, fadeTime, false);

        yield return new WaitForSeconds(fadeTime + showTime);

        IntroImage.gameObject.SetActive(false);
        finishedIntro = true;
    }
}
