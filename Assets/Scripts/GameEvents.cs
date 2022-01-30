using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
	public static void OnRoundEnded()
	{
		// TODO: Add more game logic
		var gameManager = FindObjectOfType<GameManager>();
		if (gameManager != null)
		{
			gameManager.SwitchPlayers();
		}

		FindObjectOfType<HealthController>().DecreaseHealth();
		FindObjectOfType<ScoreCounter>().FlipIsPlayer1();

		FindObjectOfType<CountdownTimer>().ResetCurrentTime();
	}

	public static void OnPlayersHealthDepleted()
	{
		FindObjectOfType<Timer>().SetShouldLoop(false);
		var scoreCounter = FindObjectOfType<ScoreCounter>();
		Debug.Log("Game finished");
		Debug.Log("Player1 Score: " + scoreCounter.player1Score);
		Debug.Log("Player2 Score: " + scoreCounter.player2Score);
	}
}
