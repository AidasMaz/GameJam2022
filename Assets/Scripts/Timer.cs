using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
	public static float periodLength = 1f;
	[SerializeField]
	private List<TimedFunction> timedFunctions;

	private bool shouldLoop = true;
	void Start()
	{
		StartCoroutine(StartTimedFunctions());
	}

	IEnumerator StartTimedFunctions()
	{
		while (shouldLoop)
		{
			// execute block of code here
			timedFunctions.ForEach(x => x.Execute());
			yield return new WaitForSeconds(periodLength);
		}
	}

	public void SetShouldLoop(bool value)
	{
		shouldLoop = value;
	}
}
