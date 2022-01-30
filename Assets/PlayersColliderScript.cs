using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Healthy")
        {
            Debug.Log("You have catched a player. Do something with your life you pervert.");
        }
        if(collision.gameObject.tag=="Corrupted")
        {
            Debug.Log("You have been caught by some weird ass pervert. U fukt");
        }
    }
}
