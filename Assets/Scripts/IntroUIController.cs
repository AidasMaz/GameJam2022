using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IntroUIController : MonoBehaviour
{
    [Header("Images")]
    [SerializeField] private Image fadeImage;
    [Space]
    [SerializeField] private Image introImage;
    [Space]
    [SerializeField] private Image controllsImage;

    [Header("Checking")]
    [SerializeField] private TextMeshProUGUI checkText;
    [Space]
    [SerializeField] private Image leftPlayer;
    [SerializeField] private Image rightPlayer;

    [Header("Variables")]
    [SerializeField] private float fadeTime;
    [SerializeField] private float showTime;

    [Header("State")]
    public IntroState introState;
    [Space]
    public CheckState checkState;

    // -------------------------------------------------

    public void Initialize()
    {
        fadeImage.gameObject.SetActive(true);
        introImage.gameObject.SetActive(true);
        controllsImage.gameObject.SetActive(true);

        SetState(IntroState.Black);

        checkState = CheckState.WaitingLeft;
    }

    private void Update()
    {
        switch (introState)
        {
            case IntroState.Black:
                break;

            case IntroState.Image:
                break;

            case IntroState.WaitingForInputs:
                switch (checkState)
                {
                    case CheckState.WaitingLeft:
                        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow) || 
                            Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                        {
                            leftPlayer.color = new Color(255, 255, 255, 255);
                            checkText.text = "Player2 press Up/Down/Left/Right";
                            checkState = CheckState.WaitingRight;
                        }
                        break;

                    case CheckState.WaitingRight:
                        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) ||
                            Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
                        {
                            rightPlayer.color = new Color(255, 255, 255, 255);
                            checkText.text = "Both players are ready";
                            checkState = CheckState.BothChecked;
                        }
                        break;

                    case CheckState.BothChecked:
                        StartCoroutine(SetStateEnded());
                        break;
                }
                break;

            case IntroState.Ended:
                break;

            default:
                break;
        }
    }

    private void SetState(IntroState state)
    {
        introState = state;

        switch (introState)
        {
            case IntroState.Black:
                StartCoroutine(FadeOutBlack());
                break;

            case IntroState.Image:
                StartCoroutine(ShowImageForTime());
                break;

            case IntroState.WaitingForInputs:

                break;

            case IntroState.Ended:

                break;

            default:
                break;
        }
    }

    IEnumerator FadeOutBlack()
    {
        yield return new WaitForSeconds(fadeTime + 0.1f);
        fadeImage.CrossFadeAlpha(0.0f, fadeTime, false);
        yield return new WaitForSeconds(fadeTime);
        SetState(IntroState.Image);
    }

    IEnumerator ShowImageForTime()
    {
        yield return new WaitForSeconds(showTime);

        fadeImage.CrossFadeAlpha(1.0f, fadeTime, false);
        yield return new WaitForSeconds(fadeTime + 0.1f);
        introImage.gameObject.SetActive(false);
        fadeImage.CrossFadeAlpha(0.0f, fadeTime, false);
        yield return new WaitForSeconds(fadeTime);
        
        SetState(IntroState.WaitingForInputs);
    }

    IEnumerator SetStateEnded()
    {
        yield return new WaitForSeconds(1.5f);

        fadeImage.CrossFadeAlpha(1.0f, fadeTime, false);
        yield return new WaitForSeconds(fadeTime + 0.1f);
        controllsImage.gameObject.SetActive(false);

        introState = IntroState.Ended;
    }
}
