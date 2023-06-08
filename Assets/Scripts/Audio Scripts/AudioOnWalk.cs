// Attach to main camera of XR origin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOnWalk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        audioSource.clip = audioClip;
        audioSource.playOnAwake = false;
        audioSource.loop = true;
        audioSource.volume = 0.5f;
        lastPositionX = gameObject.GetComponent<Transform>().position.x;
        lastPositionZ = gameObject.GetComponent<Transform>().position.z;
    }

    float interval = 0.2f;
    float nextTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        float currentPositionX = gameObject.GetComponent<Transform>().position.x;
        float currentPositionZ = gameObject.GetComponent<Transform>().position.z;
        if(Time.time >= nextTime) {
            if((lastPositionX != currentPositionX || lastPositionZ != currentPositionZ) && !soundPlaying) {
                soundPlaying = true;
                audioSource.Play();
            } else if(lastPositionX == currentPositionX && lastPositionZ == currentPositionZ && soundPlaying) {
                soundPlaying = false;
                audioSource.Stop();
            }
            lastPositionX = currentPositionX;
            lastPositionZ = currentPositionZ;
            nextTime += interval;
        }
    }

    private AudioSource audioSource;
    private float lastPositionX, lastPositionZ;
    private bool soundPlaying = false;
    public AudioClip audioClip;

}
