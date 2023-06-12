using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public enum FadeOnAwake
{
    None,
    FadeIn,
    FadeOut
}

public class ScreenFader : MonoBehaviour
{
    public float fadeDuration = 2f;
    public Color fadeColor;
    public FadeOnAwake fadeOnAwake = FadeOnAwake.None;
    public Volume volume;
    private Vignette vignette;
    private float startIntensity;
    [SerializeField] private Renderer render;

    private void Awake()
    {
        FindVolume();
        
        switch (fadeOnAwake)
        {
            case FadeOnAwake.None:
                break;
            case FadeOnAwake.FadeIn:
                FadeIn();
                break;
            case FadeOnAwake.FadeOut:
                FadeOut();
                break;
            default:
                break;
        }
    }

    public void FindVolume()
    {
        volume = FindObjectOfType<Volume>();
        if (volume != null)
        {
            if (volume.profile.TryGet<Vignette>(out vignette))
            {
                startIntensity = vignette.intensity.value;
            }
        }
    }

    public void FadeIn()
    {
        Fade(0, 1 , false);
    }

    public void FadeOut()
    {
        Fade(1, 0, true);
    }

    public void Fade(float alphaIn, float alphaOut, bool vignetteOn)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut, vignetteOn));
    }

    private IEnumerator FadeRoutine(float alphaIn, float alphaOut, bool vignetteOn)
    {
        float timer = 0;
        while(timer <= fadeDuration)
        {
            Color newColor = fadeColor;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer/fadeDuration);

            if(volume != null) vignette.intensity.value = vignetteOn ? Mathf.Lerp(0, startIntensity, timer / fadeDuration) : Mathf.Lerp(startIntensity, 0, timer / fadeDuration);

            render.material.SetColor("_BaseColor", newColor);

            timer += Time.deltaTime;
            yield return null;
        }

        Color c = fadeColor;
        c.a = alphaOut;
        if(volume != null) vignette.intensity.value = vignetteOn ? startIntensity : 0f;
        render.material.SetColor("_BaseColor", c);
    }
}
