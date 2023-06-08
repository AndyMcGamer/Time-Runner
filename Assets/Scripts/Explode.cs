using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] private float minVelocity;
    [SerializeField] private GameObject brokenPrefab;
    [SerializeField] private GameObject hammer;
    [SerializeField] private AudioSource audiosrc;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == hammer)
        {
            if(collision.rigidbody.velocity.sqrMagnitude > minVelocity * minVelocity)
            {
                GameObject resultingPrefab = Instantiate(brokenPrefab);
                foreach(Transform t in resultingPrefab.transform)
                {
                    if(t.TryGetComponent<Rigidbody>(out Rigidbody childRigidbody))
                    {
                        childRigidbody.AddExplosionForce(15f, resultingPrefab.transform.position, 0.5f);
                    }
                }
                audiosrc.Play();
                gameObject.SetActive(false);
            }
        }
    }
}
