using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private GameObject whiteFade;
    [SerializeField] private ParticleSystem particles;
    public void GotoStart()
    {
        StartCoroutine(Go());
    }

    private IEnumerator Go()
    {
        particles.Play();
        yield return new WaitForSeconds(1f);
        whiteFade.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        Destroy(PortalManager.instance.gameObject);
        SceneManager.LoadScene("Main Menu");
    }
}
