using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    public string tagFilter;    // Enter the name of a tag that can destroy this game object
    
    private void OnTriggerEnter(Collider other)     // Unity specific method
    {
        if (other.CompareTag(tagFilter)) 
        {
            Destroy(gameObject); 
        }
    }
}
