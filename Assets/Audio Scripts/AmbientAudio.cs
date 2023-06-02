using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        // currentClip = ;
        audioSource.clip = currentClip;
        audioSource.loop = true;
        audioSource.volume = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        // loopy loop to check where
        // General Form: if([criteria for clipI] and currentClip != clipI)
        //  then audioSource.clip = clipI, currentClip = Clipi
    }

    private AudioSource audioSource;
    private AudioClip currentClip;
    public AudioClip audioClip1, audioClip2, audioClip3, audioClip4;

}
