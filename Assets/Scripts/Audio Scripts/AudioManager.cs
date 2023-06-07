using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] listOfSounds;
    public static AudioManager instance;
    void Awake()
    {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound sound in listOfSounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>() as AudioSource;
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.spatialBlend = sound.spatialBlend;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(string nameOfSound) {
        Sound s = Array.Find(listOfSounds, sound => sound.nameOfSound == nameOfSound);
        if(s == null) return;
        s.audioSource.Play();
    }

    public void PlayAfterDelay(string nameAndDelay)
    {
        string[] split = nameAndDelay.Split(',');
        string nameOfSound = split[0];
        float delay = float.Parse(split[1]);
        Sound s = Array.Find(listOfSounds, sound => sound.nameOfSound == nameOfSound);
        if (s == null) return;
        StartCoroutine(PlayDelay(s, delay));
    }

    private IEnumerator PlayDelay(Sound s, float t)
    {
        yield return new WaitForSeconds(t);
        s.audioSource.Play();
    }

    // FindObjectOfType<AudioManager>().Play("name");

    
}
