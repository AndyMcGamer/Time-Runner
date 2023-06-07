using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

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

    // FindObjectOfType<AudioManager>().Play("name");

    public Sound[] listOfSounds;
    public static AudioManager instance;
}
