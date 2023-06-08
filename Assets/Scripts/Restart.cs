using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private GameObject whiteFade;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private AudioSource src;
    public void GotoStart()
    {
        StartCoroutine(Go());
    }

    private IEnumerator Go()
    {
        particles.Play();
        src.PlayOneShot(src.clip);
        yield return new WaitForSeconds(2f);
        whiteFade.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        Destroy(PortalManager.instance.gameObject);
        SceneManager.LoadScene("Main Menu");
    }
}
