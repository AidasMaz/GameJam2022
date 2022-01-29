using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] private UIController uiController;
    // sound controller
    // players controller
    // timer controller

    // -------------------------------------------------

    private void Start()
    {
        uiController.Initialize();
    }

    public void StartGame()
    {
        uiController.StartGame();
    }

    public void SwitchPlayers()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        
    }
}
