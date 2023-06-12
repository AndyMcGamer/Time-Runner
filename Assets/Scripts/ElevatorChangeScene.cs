using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorChangeScene : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private ScreenFader fade;

    private void Awake()
    {
        fade = SceneController.instance.fade;
    }
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
        yield return new WaitForSeconds(4f);
        fade.fadeColor = new Color(0, 0, 0);
        fade.fadeDuration = 1f;
        fade.FadeIn();
        yield return new WaitForSeconds(1f);
        Destroy(PortalManager.instance.gameObject);
        SceneController.instance.LoadScene("MainFloor");
    }
}
