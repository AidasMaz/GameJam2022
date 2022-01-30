using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
	[SerializeField] Transform spawnPoint;

	public void Respawn()
	{
		transform.position = spawnPoint.position;
	}
}
