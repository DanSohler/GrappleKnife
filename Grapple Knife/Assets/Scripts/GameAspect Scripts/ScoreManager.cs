using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("Player Statistics")]
    public int playerScore;
    public float playerTime;

    [Header("Game Difficulty")]
    public float gameTier;
    public float[] tierRanks;

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

    private void Update()
    {
        //updates game tier based off score
        if (playerScore >= 3)
        {
            gameTier = tierRanks[1];

            if (playerScore >= 5)
            {
                gameTier = tierRanks[2];
            }
        }
    }

    public void ResetScores()
    {
        playerScore = 0;
        playerTime = 0;

        gameTier = tierRanks[0];
    }
}
