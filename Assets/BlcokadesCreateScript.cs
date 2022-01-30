using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlcokadesCreateScript : MonoBehaviour
{
    public GameObject prefab;

    public AudioSource audio;

    public PlayerMovementController playerMovementController;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerMovementController.type == CharacterType.HEALTHY)
        {
            audio.Play();
            Vector2 pos = transform.position;
            Quaternion rot = Quaternion.identity;
            Instantiate(prefab, pos, rot);
        }
    }
}
