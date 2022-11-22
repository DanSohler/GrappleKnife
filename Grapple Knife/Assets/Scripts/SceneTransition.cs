using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator transitonAnim;
    public float transitionTime = 1f;

    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadMainMenu());
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        StartCoroutine(ExitGame());
    }


    IEnumerator LoadLevel(int levelIndex)
    {
        transitonAnim.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(transitionTime);
        Debug.Log("Load level");
        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator LoadMainMenu()
    {
        transitonAnim.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(transitionTime);
        Debug.Log("Load main menu");
        SceneManager.LoadScene(0);
    }

    IEnumerator ExitGame()
    {
        transitonAnim.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(transitionTime);
        Debug.Log("GameQuit"); 
        Application.Quit();
    }

}
