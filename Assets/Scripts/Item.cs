using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Item : MonoBehaviour
{
    public int layer;
    [SerializeField] private Renderer render;
    [SerializeField] private Rigidbody rb;
    public Transform parent;
    private RaycastHit[] hits;

    private void Awake()
    {
        parent = transform.parent;
        hits = new RaycastHit[10];
    }

    private void OnEnable()
    {
        gameObject.GetComponent<XRGrabInteractable>().selectEntered.AddListener(PickedUp);
        
    }

    private void OnDisable()
    {
        gameObject.GetComponent<XRGrabInteractable>().selectEntered.RemoveListener(PickedUp);
    }

    public void PickedUp(BaseInteractionEventArgs args)
    {
        if(args.interactorObject is XRDirectInteractor)
        {
            gameObject.layer = 0;
            transform.parent = parent;
        }
        
    }

    public void Dropped()
    {
        gameObject.layer = layer;
    }

    private void Update()
    {
        if (gameObject.layer != 0){
            parent = transform.parent;
            render.enabled = false;
            rb.useGravity = false;
            int count = Physics.RaycastNonAlloc(transform.position, Vector3.up, hits, 20f, 1 << layer);
            for (int i = 0; i < count; i++)
            {
                RaycastHit hit = hits[i];
                if (hit.collider.gameObject.name != gameObject.name)
                {
                    render.enabled = true;
                    rb.useGravity = true;
                    break;
                }
            }

        }
        else
        {
            if (Physics.Raycast(transform.position, Vector3.up, out RaycastHit ray, 20f))
            {
                if (ray.collider.gameObject.name != gameObject.name) layer = ray.collider.gameObject.layer;
            }
        }
    }

}
