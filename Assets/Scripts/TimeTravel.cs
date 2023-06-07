using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    [SerializeField] private ParticleSystem timeTravelContinuous;
    [SerializeField] private ParticleSystem timeTravelFX;
    [SerializeField] private GameObject whiteFade;
    [SerializeField] private Collider col;
    public void FixedPortal()
    {
        timeTravelContinuous.Play();
        col.enabled = true;
        gameObject.tag = "Collider";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ChangeEnviro());
        }
    }

    private IEnumerator ChangeEnviro()
    {
        timeTravelFX.Play();
        yield return new WaitForSeconds(1f);
        whiteFade.SetActive(true);
        yield return new WaitForSeconds(3f);
        whiteFade.SetActive(false);

    }
}
