using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] GameObject imageObject;

    public static void FirstScene()
    {
        SceneManager.LoadScene("Start");
    }
    public static void ReloadScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public static void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        SceneManager.LoadScene(sceneIndex);
    }

    public static void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void StartScenePlayer()
    {
        StopCoroutine(nameof(LoadNextSceneCoroutine));
        StartCoroutine(nameof(LoadNextSceneCoroutine));
    }
    IEnumerator LoadNextSceneCoroutine()
    {

        imageObject.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        int sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        SceneManager.LoadScene(sceneIndex);
    }
}