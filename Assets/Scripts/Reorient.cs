using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Management;
using UnityEngine.XR;

public class Reorient : MonoBehaviour
{
    List<Vector3> boundaryPoints;
    
    private void Start()
    {
        var loader = XRGeneralSettings.Instance.Manager?.activeLoader;
        if (loader == null)
        {
            Debug.LogWarning("Could not get active Loader.");
            return;
        }
        var inputSubsystem = loader.GetLoadedSubsystem<XRInputSubsystem>();
        inputSubsystem.boundaryChanged += SetupBoundary;
    }

    private void SetupBoundary(XRInputSubsystem inputSubsystem)
    {
        boundaryPoints = new List<Vector3>();
        if (inputSubsystem.TryGetBoundaryPoints(boundaryPoints))
        {
            foreach (var point in boundaryPoints)
            {
                Debug.Log(point);
            }
        }
        else
        {
            Debug.LogWarning($"Could not get Boundary Points for Loader");
        }
    }
}
