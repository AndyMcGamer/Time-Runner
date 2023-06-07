using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        currentClip = audioClip1;
        audioSource.clip = currentClip;
        audioSource.loop = true;
        audioSource.volume = 0.2f;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        // loopy loop to check where
        // General Form: if([criteria for clipI] and currentClip != clipI)
        //  then audioSource.clip = clipI, currentClip = Clipi
        if(temp1 && currentClip != audioClip2) {
            audioSource.Stop();
            currentClip = audioClip2;
            audioSource.clip = currentClip;
            audioSource.Play();
        } else if(temp2 && currentClip != audioClip3) {
            audioSource.Stop();
            currentClip = audioClip3;
            audioSource.clip = currentClip;
            audioSource.Play();
        }
    }

    private AudioSource audioSource;
    private AudioClip currentClip;
    private bool temp1 = false, temp2 = false;
    public AudioClip audioClip1, audioClip2, audioClip3;

}
