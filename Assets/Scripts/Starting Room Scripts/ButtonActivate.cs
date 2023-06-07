using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivate : MonoBehaviour
{
    [SerializeField] private Animator anim;
    bool played = false;

    public void Activate()
    {
        if (played) return;
        anim.Play("DoorLowering");
        played = true;
        AudioManager.instance.Play("button");
        AudioManager.instance.PlayAfterDelay("gate,2");
    }
}
