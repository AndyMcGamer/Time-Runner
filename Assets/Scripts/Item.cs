using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Collider col;
    [SerializeField] private Transform player;
    [SerializeField] private float distThreshold;
    private void Update()
    {
        if((transform.position - player.position).sqrMagnitude > distThreshold)
        {
            rb.useGravity = false;
            col.enabled = false;
        }
        else
        {
            rb.useGravity = true;
            col.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Portal"))
        {

        }
    }
}
