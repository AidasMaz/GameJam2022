using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : TimedFunction
{
	public int player1Score { get; private set; }
	public int player2Score { get; private set; }
	public bool isPlayer1 { get; private set; }
	private int scoreInc = (int)(Timer.periodLength * 10);
	void Start()
	{
		player1Score = 0;
		player2Score = 0;
		isPlayer1 = true;
	}
	public override void Execute()
	{
		if (isPlayer1)
		{
			player1Score += scoreInc;
			// Debug.Log("Player1: " + player1Score);
		}
		else
		{
			player2Score += scoreInc;
			// Debug.Log("Player2: " + player2Score);
		}
	}

	public void FlipIsPlayer1()
	{
		isPlayer1 = !isPlayer1;
	}
}
