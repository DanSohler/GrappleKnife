using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public bool gameIsActive;
    public GameObject startUI;
    public UnityEvent gameStart;

    //start with a input screen, once a player clicks a button, start the game
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        GamesStatus(false);
        startUI.SetActive(true);
    }

    public void GamesStatus(bool activeStatus)
    {
        gameIsActive = activeStatus;
        if (activeStatus)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            startUI.SetActive(false);
            gameStart.Invoke();
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            startUI.SetActive(false);
        }
    }

    public void Endgame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }


    #region Difficulty








    #endregion
}
