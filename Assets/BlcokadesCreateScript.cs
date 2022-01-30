using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlcokadesCreateScript : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Vector2 pos = transform.position;
            Quaternion rot = Quaternion.identity;
            Instantiate(prefab, pos, rot);
        }
    }
}
