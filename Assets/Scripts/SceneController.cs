using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    public ScreenFader fade;
    public MeshRenderer cameraMask;
    public GameObject xrOrigin;
    public Transform cameraOrigin;
    public Transform rotationOrigin;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Main Menu", LoadSceneMode.Additive);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += SetActiveScene;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SetActiveScene;
    }

    public void LoadScene(string name)
    {

        StartCoroutine(SceneLoad(name));
    }

    private IEnumerator SceneLoad(string name)
    {
        AsyncOperation unload = SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        while (!unload.isDone) { yield return null; }
        AsyncOperation load = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
        yield return load;
    }

    private void SetActiveScene(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
        fade.FindVolume();
        
    }
}
