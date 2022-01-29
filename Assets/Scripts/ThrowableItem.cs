using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ThrowableItem : MonoBehaviour
{
	[SerializeField]
	private float cooldown = 5f;
	private float myTime = 0;
	public bool isOnCooldown { get { return myTime > 0; } }

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (myTime > 0)
		{
			myTime -= Time.deltaTime;
		}
	}

	public void ThrowItem()
	{
		ThrowEffect();
		myTime = cooldown;
	}

	protected abstract void ThrowEffect();
}
