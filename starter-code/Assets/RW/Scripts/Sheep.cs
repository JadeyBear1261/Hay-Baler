using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    public float runSpeed;  // Meters per second
    public float gotHayDestroyDelay;    // Delay sheep after hay hit
    private bool hitByHay; 
    private bool dropped; 
    public float dropDestroyDelay; 
    private Collider myCollider; 
    private Rigidbody myRigidbody; 
    private SheepSpawner sheepSpawner;
    public float heartOffset; 
    public GameObject heartPrefab; 

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);   //Sheep run forward vector at runSpeed
    }

    private void HitByHay() // Hit by hay set to true after called
    {
        GameStateManager.Instance.SavedSheep();     //Sheep saved to gamemanger message
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity); // New heart above sheep
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();
        tweenScale.targetScale = 0; 
        tweenScale.timeToReachTarget = gotHayDestroyDelay;
        SoundManager.Instance.PlaySheepHitClip();

        sheepSpawner.RemoveSheepFromList(gameObject);
        hitByHay = true; 
        runSpeed = 0;

        Destroy(gameObject, gotHayDestroyDelay);
    }

    private void OnTriggerEnter(Collider other)     // Tag conditions
    {
        if (other.CompareTag("Hay") && !hitByHay) 
        {
            Destroy(other.gameObject);  // Hay
            HitByHay(); 
        }
        
        else if (other.CompareTag("DropSheep") && !dropped) // If sheep hit my something other than hay, check for tag
        {
            Drop();
        }
    }

    private void Drop()
    {
        SoundManager.Instance.PlaySheepDroppedClip();
        GameStateManager.Instance.DroppedSheep();       //Tells manager sheep dropped
        sheepSpawner.RemoveSheepFromList(gameObject);
        dropped = true;
        myRigidbody.isKinematic = false;    // Unity gravity will take effect
        myCollider.isTrigger = false;       //Not affected by trigger zone
        Destroy(gameObject, dropDestroyDelay); // Self destruct
    }

    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }
}
