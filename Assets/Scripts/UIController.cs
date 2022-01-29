using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
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

    public void Initialize()
    {
        introPanelObj.SetActive(true);

        startUIPanelObj.SetActive(false);
        endUIPanelObj.SetActive(false);
        gameplayUIPanelObj.SetActive(false);

        SetState(GameState.Intro);
    }

    private void SetState(GameState state)
    {
        gameState = state;

        switch (gameState)
        {
            case GameState.Intro:
                introPanelObj.SetActive(true);
                introUIController.Initialize();
                break;

            case GameState.StartScreen:
                introPanelObj.SetActive(false);
                startUIPanelObj.SetActive(true);
                break;

            case GameState.GamePlay:
                gameplayUIPanelObj.SetActive(true);
                break;

            case GameState.EndScreen:
                startUIPanelObj.SetActive(true);
                break;

            default:
                break;
        }
    }

    public void StartGame()
    {
        if (gameState == GameState.StartScreen)
        {
            SetState(GameState.GamePlay);
        }
    }

    void Update()
    {
        switch (gameState)
        {
            case GameState.Intro:
                if (introUIController.finishedIntro)
                {
                    SetState(GameState.StartScreen);
                }
                break;
            case GameState.StartScreen:
                break;
            case GameState.GamePlay:
                break;
            case GameState.EndScreen:
                break;
            default:
                break;
        }
    }
}
