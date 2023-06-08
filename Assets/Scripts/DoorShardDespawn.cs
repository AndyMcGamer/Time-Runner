using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorShardDespawn : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Despawn());
    }

    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(6f);
        gameObject.SetActive(false);
    }
}
