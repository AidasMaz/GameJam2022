using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
	public static void OnCountdownTimerEnded(CountdownTimer timer)
	{
		// TODO: Add more game logic
		var gameManager = FindObjectOfType<GameManager>();
		if (gameManager != null)
		{
			gameManager.SwitchPlayers();
		}

		FindObjectOfType<ScoreCounter>().FlipIsPlayer1();

		timer.ResetCurrentTime();
	}
}
