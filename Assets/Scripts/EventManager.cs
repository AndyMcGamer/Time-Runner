using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public delegate void EnviroSwitchHandle();
    public static event EnviroSwitchHandle OnSwitchEnviro;

    public static void SwitchEnviro()
    {
        OnSwitchEnviro?.Invoke();
    }
}
