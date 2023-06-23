using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour

{
    public Vector3 movementSpeed;   //How much hay bale should move along axes
    public Space space;     // Unity space to set world or self

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movementSpeed * Time.deltaTime, space);     //Move hay bale to move on specific axis by specific amount and space variable
    }
}
