using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketHolder : MonoBehaviour
{
    [SerializeField] private XRSocketInteractor socket;

    private float timeSinceExit;
    private IXRSelectInteractable lastSelectedObject;

    public bool alreadySelected { get { return lastSelectedObject != null; } }

    private void Awake()
    {
        timeSinceExit = Time.time;
        lastSelectedObject = null;
    }

    private void OnEnable()
    {
        if (lastSelectedObject != null)
        {
            socket.StartManualInteraction(lastSelectedObject);
        }
        socket.selectExited.AddListener(CheckSocket);
        socket.selectEntered.AddListener(DropItem);
    }

    public void DropItem(BaseInteractionEventArgs args)
    {
        args.interactableObject.transform.gameObject.GetComponent<Item>().Dropped();
    }

    public void CheckSocket(BaseInteractionEventArgs args)
    {
        if(args.interactableObject is XRGrabInteractable interactable)
        {
            timeSinceExit = Time.time;
            lastSelectedObject = interactable;
        }
        
        
    }

    private void OnDisable()
    {
        if (Time.time - timeSinceExit > 0.01f) lastSelectedObject = null;
        socket.selectExited.RemoveListener(CheckSocket);
        socket.selectEntered.RemoveListener(DropItem);
    }
}
