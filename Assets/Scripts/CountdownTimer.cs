using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : TimedFunction
{
	[SerializeField]
	private TextMeshProUGUI countdownText;
	[SerializeField]
	private float startTime = 60;
	private float periodLength;

	private float currentTime;
	// Start is called before the first frame update
	void Start()
	{
		periodLength = Timer.periodLength;

		currentTime = startTime + periodLength;
	}

	public override void Execute()
	{
		if (currentTime < periodLength)
			return;
		currentTime -= periodLength;
		countdownText.text = currentTime.ToString();
		// Debug.Log("Countdown: " + currentTime.ToString());

		if (currentTime <= 0)
		{
			GameEvents.OnRoundEnded();
		}
	}

	public void ResetCurrentTime()
	{
		currentTime = startTime;
	}
}
