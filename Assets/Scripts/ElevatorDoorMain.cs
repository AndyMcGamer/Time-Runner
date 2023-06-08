using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoorMain : MonoBehaviour
{
    public GameObject elevator;
    public GameObject fakeWall;
    public Animator anim;

    private void Awake()
    {
        anim.Play("ElevatorOpen");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play("ElevatorClose");
            StartCoroutine(HideElevator());
        }
    }
    private IEnumerator HideElevator()
    {
        yield return new WaitForSeconds(2f);
        elevator.SetActive(false);
        anim.enabled = false;
        fakeWall.SetActive(true);
        enabled = false;
    }
}
