using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintColors : MonoBehaviour
{
    public Light lightObject;
    public bool useRainbowColors;
    public Gradient colorGradient;
    public float duration = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (useRainbowColors && lightObject)
        {
            float lerp = Mathf.PingPong(Time.time, duration) / duration;
            lightObject.color = colorGradient.Evaluate(lerp);
        }
    }
}
