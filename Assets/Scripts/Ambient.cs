using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambient : MonoBehaviour
{
    public AudioSource discover;
    public AudioSource metallic;
    private bool d = true;
    private void Awake()
    {
        discover.Play();
        d = true;
    }

    public void Switch()
    {
        discover.Stop();
        metallic.Stop();
        d = !d;
        if (d) discover.Play();
        else metallic.Play();
    }
}
