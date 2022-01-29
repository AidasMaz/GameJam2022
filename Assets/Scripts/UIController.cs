using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Black object")]
    [SerializeField] private Image blackImage;

    [Header("Intro objects")]
    [SerializeField] private GameObject introPanelObj;

    [Header("Start UI objects")]
    [SerializeField] private GameObject startUIPanelObj;

    [Header("End UI objects")]
    [SerializeField] private GameObject endUIPanelObj;

    [Header("Gameplay UI objects")]
    [SerializeField] private GameObject gameplayUIPanelObj;

    [Header("States")]
    private GameState gameState;

    [Header("Controllers")]
    [SerializeField] private IntroUIController introUIController;
    //[SerializeField] private GameplayUIController gameplayUIController;
    //[SerializeField] private endUIController endUIController;

    // -------------------------------------------------

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        startUIPanelObj.SetActive(true);

        introPanelObj.SetActive(false);
        endUIPanelObj.SetActive(false);
        gameplayUIPanelObj.SetActive(false);

        SetState(GameState.BlackFade);
    }

    private void SetState(GameState state)
    {
        gameState = state;

        switch (gameState)
        {
            case GameState.BlackFade:
                StartCoroutine(FadeOutBlack());
                break;

            case GameState.StartScreen:
                break;

            case GameState.GameplayIntro:
                startUIPanelObj.SetActive(false);
                introPanelObj.SetActive(true);
                introUIController.Initialize();
                break;

            case GameState.Gameplay:
                StartCoroutine(FadeOutBlackToGameplay());
                introPanelObj.SetActive(false);
                gameplayUIPanelObj.SetActive(true);
                break;

            case GameState.EndScreen:

                break;

            default:
                break;
        }
    }

    public void StartGame()
    {
        if (gameState == GameState.StartScreen)
        {
            StartCoroutine(FadeInBlackToGameplayIntro());
        }
    }

    void Update()
    {
        switch (gameState)
        {
            case GameState.BlackFade:
                break;

            case GameState.StartScreen:
                break;

            case GameState.GameplayIntro:
                if (introUIController.introState == IntroState.Ended)
                {
                    SetState(GameState.Gameplay);
                }
                break;

            case GameState.Gameplay:
                break;

            case GameState.EndScreen:
                break;

            default:
                break;
        }
    }

    IEnumerator FadeOutBlack()
    {
        yield return new WaitForSeconds(1.0f);

        blackImage.CrossFadeAlpha(0.0f, 1.0f, false);

        yield return new WaitForSeconds(1.0f);

        SetState(GameState.StartScreen);
    }
    IEnumerator FadeInBlackToGameplayIntro()
    {
        blackImage.CrossFadeAlpha(1.0f, 1.0f, false);

        yield return new WaitForSeconds(1.0f);

        blackImage.gameObject.SetActive(false);
        SetState(GameState.GameplayIntro);
    }
    IEnumerator FadeOutBlackToGameplay()
    {
        blackImage.gameObject.SetActive(true);
        blackImage.CrossFadeAlpha(1.0f, 0.0f, false);
        blackImage.CrossFadeAlpha(0.0f, 1.0f, false);
        yield return new WaitForSeconds(1.0f);
        blackImage.gameObject.SetActive(false);
    }
}
