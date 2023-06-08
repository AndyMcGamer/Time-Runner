using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int layer;
    private bool held;

    public void PickedUp()
    {
        gameObject.layer = 0;
        held = true;
    }

    public void Dropped()
    {
        gameObject.layer = layer;
        held = false;
    }

}
