using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private ScreenFader fade;

    private void Awake()
    {
        fade = SceneController.instance.fade;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) StartCoroutine(PlayGame());
    }

    private IEnumerator PlayGame()
    {
        fade.fadeColor = new Color(0, 0, 0);
        fade.fadeDuration = 1.2f;
        fade.FadeIn();
        yield return new WaitForSeconds(1.2f);
        //SceneManager.LoadScene("Starter");
        SceneController.instance.LoadScene("Starter");
    }
}
