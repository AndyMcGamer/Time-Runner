using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private ScreenFader fader;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private AudioSource src;

    private void Awake()
    {
        fader = SceneController.instance.fade;
    }

    public void GotoStart()
    {
        StartCoroutine(Go());
    }

    private IEnumerator Go()
    {
        yield return new WaitForSeconds(1f);
        particles.Play();
        src.PlayOneShot(src.clip);
        yield return new WaitForSeconds(2f);
        //whiteFade.SetActive(true);
        fader.fadeColor = new Color(1, 1, 1);
        fader.fadeDuration = 1.5f;
        fader.FadeIn();
        yield return new WaitForSeconds(2.5f);
        Destroy(PortalManager.instance.gameObject);
        SceneController.instance.LoadScene("Main Menu");
    }
}
