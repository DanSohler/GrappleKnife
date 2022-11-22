using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int playerScore;
    public float playerTime;

    public static ScoreManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            this.gameObject.transform.parent = null;
            DontDestroyOnLoad(this.gameObject);
        }
        
    }

    public void ResetScores()
    {
        playerScore = 0;
        playerTime = 0;
    }
}
