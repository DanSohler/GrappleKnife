using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public bool gameIsActive;
    public GameObject PauseUi;
    public UnityEvent gameStart;

    private bool pauseFlag;
    public GameObject PauseText;

    //start with a input screen, once a player clicks a button, start the game
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        GamesStatus(true);
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && !pauseFlag)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseFlag)
        {
            ResumeGame();
        }
    }

    public void GamesStatus(bool activeStatus)
    {
        gameIsActive = activeStatus;
        if (activeStatus)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            PauseUi.SetActive(false);
            gameStart.Invoke();
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;
            PauseUi.SetActive(false);
        }
    }

    // pause Logic

    public void PauseGame()
    {
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        pauseFlag = true;
        PauseUi.SetActive(true);
        PauseText.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        pauseFlag = false;
        PauseUi.SetActive(false);
        PauseText.SetActive(true);
    }




    #region Difficulty








    #endregion
}
