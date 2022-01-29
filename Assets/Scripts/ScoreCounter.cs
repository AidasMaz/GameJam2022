using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : TimedFunction
{
	private int player1Score = 0;
	private int player2Score = 0;
	private bool isPlayer1 = true;
	private int scoreInc = (int)(Timer.periodLength * 10);
	public override void Execute()
	{
		if (isPlayer1)
		{
			player1Score += scoreInc;
			Debug.Log("Player1: " + player1Score);
		}
		else
		{
			player2Score += scoreInc;
			Debug.Log("Player2: " + player2Score);

		}
	}

	public void FlipIsPlayer1()
	{
		isPlayer1 = !isPlayer1;
	}
}
