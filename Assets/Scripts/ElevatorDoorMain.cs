using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorDoorMain : MonoBehaviour
{
    public GameObject elevator;
    public GameObject fakeWall;
    public Animator anim;
    public ScreenFader fader;

    private void Awake()
    {
        fader = SceneController.instance.fade;
        SceneController.instance.xrOrigin.transform.position = new Vector3(1.25f, -0.25f, -3.25f);
        SceneController.instance.cameraOrigin.localPosition = -Camera.main.transform.localPosition;
        SceneController.instance.rotationOrigin.Rotate(180f * Vector3.up);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += StartIt;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= StartIt;
    }

    private void StartIt(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(Starter());
    }

    private IEnumerator Starter()
    {
        fader.FadeOut();
        yield return new WaitForSeconds(0.8f);
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
