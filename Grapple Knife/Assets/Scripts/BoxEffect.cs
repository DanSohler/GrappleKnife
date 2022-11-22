using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxEffect : MonoBehaviour
{
    [Header("Refences")]
    [SerializeField] BoxSpawner boxHandler;
    [SerializeField] CountdownTimer countdownHandler;

    [SerializeField] ScoreManager sm;

    [Header("vars")]
    [SerializeField] float boxTier;

    private void Awake()
    {
        boxHandler = FindObjectOfType<BoxSpawner>();
        countdownHandler = FindObjectOfType<CountdownTimer>();
        sm = FindObjectOfType<ScoreManager>();

        //Add funt to make them grow from nothing to expected size, looks better than popping in
    }

    public void BoxHit()
    {
        //one time if, just activates the game
        if (sm.playerScore == 0)
        {
            //Start game from here
            countdownHandler.StartTimer();

            //Gifts time to player, takes tier and multiplis it by 5, add funct to slowly degrade boxtier over time in another script
            countdownHandler.AddTImeToTimer(boxTier * 5);
            //Sets up next box
            boxHandler.BoxKilled();
            //Add score to score tracker
            sm.playerScore++;
        }
        else if (sm.playerScore >= 1)
        {
            countdownHandler.AddTImeToTimer(boxTier * 5);
            boxHandler.BoxKilled();
            sm.playerScore++;
        }
        return;
    }

}
