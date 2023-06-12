using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientAudio : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip currentClip;
    private bool temp1 = false, temp2 = false;
    public AudioClip audioClip1, audioClip2, audioClip3;

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        currentClip = audioClip1;
        audioSource.clip = currentClip;
        audioSource.loop = true;
        audioSource.volume = 0.4f;
        audioSource.Play();
        SceneController.instance.fade.FadeOut();
        SceneController.instance.xrOrigin.transform.position = new Vector3(2f, -1.5f, -5.25f);
        SceneController.instance.cameraOrigin.localPosition = -Camera.main.transform.localPosition;
        SceneController.instance.rotationOrigin.Rotate(90f * Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        // loopy loop to check where
        // General Form: if([criteria for clipI] and currentClip != clipI)
        //  then audioSource.clip = clipI, currentClip = Clipi
        if (temp1 && currentClip != audioClip2) {
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

    

}
