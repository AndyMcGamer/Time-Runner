using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorChangeScene : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.Play("ElevatorClose");
            StartCoroutine(ElevatorScene());
        }
    }

    private IEnumerator ElevatorScene()
    {
        yield return new WaitForSeconds(2f);
        anim.enabled = false;
        yield return new WaitForSeconds(1f);
        AudioManager.instance.Play("elevator");
        yield return new WaitForSeconds(4.5f);
        Destroy(PortalManager.instance.gameObject);
        SceneManager.LoadScene("MainFloor");
    }
}
