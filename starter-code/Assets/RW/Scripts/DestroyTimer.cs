using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour //Destroy heart
{
    public float timeToDestroy;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy);     // Timer
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
