using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int layer;
    [SerializeField] private Renderer render;
    [SerializeField] private Rigidbody rb;

    public void PickedUp()
    {
        gameObject.layer = 0;
    }

    public void Dropped()
    {
        gameObject.layer = layer;
    }

    private void Update()
    {
        if (gameObject.layer != 0){
            if(Physics.Raycast(transform.position, Vector3.up, 20f, 1 << layer))
            {
                render.enabled = true;
                rb.useGravity = true;
            }
            else
            {
                render.enabled = false;
                rb.useGravity = false;
            }
        }
        else
        {
            if (Physics.Raycast(transform.position, Vector3.up, out RaycastHit ray, 20f))
            {
                layer = ray.collider.gameObject.layer;
            }
        }
    }

}
