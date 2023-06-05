using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPress : MonoBehaviour
{
    [SerializeField] private XRBaseInteractable interactable;
    private Vector3 offset;
    [SerializeField] private Transform visualTarget;
    private bool following = false;
    private Transform pokeAttachTransform;
    private Vector3 initialPos;
    [SerializeField] private Vector3 localAxis;
    [SerializeField] private float resetSpeed = 2f;
    [SerializeField] private float angleThreshold = 45f;
    private bool freeze;

    private void OnEnable()
    {
        initialPos = visualTarget.localPosition;

        interactable.hoverEntered.AddListener(Follow);
        interactable.hoverExited.AddListener(ResetButton);
        interactable.selectEntered.AddListener(Freeze);
    }

    private void OnDisable()
    {
        interactable.hoverEntered.RemoveListener(Follow);
        interactable.hoverExited.RemoveListener(ResetButton);
    }

    private void Follow(BaseInteractionEventArgs hover)
    {
        if(hover.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor) hover.interactorObject;
            following = true;
            freeze = false;

            pokeAttachTransform = interactor.attachTransform;
            offset = visualTarget.position - pokeAttachTransform.position;

            float pokeAngle = Vector3.Angle(offset, visualTarget.TransformDirection(localAxis));

            if(pokeAngle > angleThreshold)
            {
                following = false;
                freeze = true;
            }
        }
    }

    private void ResetButton(BaseInteractionEventArgs hover)
    {
        if(hover.interactorObject is XRPokeInteractor)
        {
            following = false;
            freeze = false;
        }
    }
    
    private void Freeze(BaseInteractionEventArgs select)
    {
        if (select.interactorObject is XRPokeInteractor)
        {
            freeze = true;
        }
    }

    private void Update()
    {
        if (freeze) return;

        if (following)
        {
            Vector3 localTargetPos = visualTarget.InverseTransformPoint(pokeAttachTransform.position + offset);
            Vector3 constrainedPos = Vector3.Project(localTargetPos, localAxis);
            visualTarget.position = visualTarget.TransformPoint(constrainedPos);
        }
        else
        {
            visualTarget.localPosition = Vector3.Lerp(visualTarget.localPosition, initialPos, resetSpeed * Time.deltaTime);
        }
    }
}
