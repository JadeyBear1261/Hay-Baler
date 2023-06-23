using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour   // Sound effects
{
    public static SoundManager Instance; 

    public AudioClip shootClip; 
    public AudioClip sheepHitClip; 
    public AudioClip sheepDroppedClip; 

    private Vector3 cameraPosition; 

    // Awake fires before start
    void Awake()
    {
        Instance = this;    // Cache the script in 'this' instance
        cameraPosition = Camera.main.transform.position;    // Cache the position of camera
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaySound(AudioClip clip)  // Plays audio clip at the camera
    {
        AudioSource.PlayClipAtPoint(clip, cameraPosition);
    }

    public void PlayShootClip()     // Sound effect on shoot
    {
        PlaySound(shootClip);
    }

    public void PlaySheepHitClip()      // Sound effect on sheep hit
    {
        PlaySound(sheepHitClip);
    }

    public void PlaySheepDroppedClip()      // Sound effect on sheep drop
    {
        PlaySound(sheepDroppedClip);
    }
}
