using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
	[SerializeField]
	private int startingLife = 3;
	public int currentPlayer1HP { get; private set; }
	public int currentPlayer2HP { get; private set; }

	private ScoreCounter scoreCounter;
	// Start is called before the first frame update
	void Start()
	{
		currentPlayer1HP = startingLife;
		currentPlayer2HP = startingLife;

		scoreCounter = FindObjectOfType<ScoreCounter>();
	}

	public void DecreaseHealth()
	{
		if (scoreCounter.isPlayer1 && currentPlayer1HP > 0)
		{
			currentPlayer1HP--;
		}
		else if (currentPlayer2HP > 0)
		{
			currentPlayer2HP--;
		}
		Debug.Log("Player1 HP: " + currentPlayer1HP + " Player2 HP: " + currentPlayer2HP);
		if (currentPlayer1HP == 0 && currentPlayer2HP == 0)
		{
			GameEvents.OnPlayersHealthDepleted();
		}
	}

}
