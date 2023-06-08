using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStencil : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            other.GetComponent<Item>().layer = gameObject.layer;
        }
    }
}
