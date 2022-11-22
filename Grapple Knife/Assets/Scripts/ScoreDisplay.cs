using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [Header("Refs")]
    ScoreManager sm;

    [SerializeField] TextMeshProUGUI playerDurationtext;
    [SerializeField] TextMeshProUGUI playerScoreText;

    private void Awake()
    {
        sm = FindObjectOfType<ScoreManager>();

        float minutes = Mathf.FloorToInt(sm.playerTime / 60);
        float seconds = Mathf.FloorToInt(sm.playerTime % 60);
        playerDurationtext.text = string.Format("{0:00}:{1:00}!", minutes, seconds);

        //
        //playerScoreText.text = sm.playerScore.ToString();
        if (sm.playerScore == 1)
        {
            //Just here for proper grammar
            playerScoreText.text = string.Format("{0} Crystal!", sm.playerScore);
        }
        else if (sm.playerScore == 0 || sm.playerScore > 1)
        {
            playerScoreText.text = string.Format("{0} Crystals!", sm.playerScore);
        }
    }
}
