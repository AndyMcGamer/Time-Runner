using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyScanner : MonoBehaviour
{
    [SerializeField] private SocketHolder key;
    [SerializeField] private XRSocketInteractor socket;

    private void OnEnable()
    {
        socket.selectEntered.AddListener(PlayKeySound);
    }

    private void PlayKeySound(BaseInteractionEventArgs args)
    {
        if (!key.alreadySelected) AudioManager.instance.Play("ekey");
    }

    private void OnDisable()
    {
        socket.selectEntered.RemoveListener(PlayKeySound);
    }

}
