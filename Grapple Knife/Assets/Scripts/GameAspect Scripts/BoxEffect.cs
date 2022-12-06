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
    [SerializeField] GameObject hitVFX;

    private void Awake()
    {
        boxHandler = FindObjectOfType<BoxSpawner>();
        countdownHandler = FindObjectOfType<CountdownTimer>();
        sm = FindObjectOfType<ScoreManager>();

        //Add funt to make them grow from nothing to expected size, looks better than popping in
    }

    private void Update()
    {
        //Update box tier whenever game tier is updated
        boxTier = sm.gameTier;
    }

    public void BoxHit()
    {
        //one time if, just activates the game
        if (sm.playerScore == 0)
        {
            //Spawns vfx

            Instantiate(hitVFX, transform);

            //Start game from here
            countdownHandler.StartTimer();

            //Gifts time to player, takes tier and multiplis it by 10, add funct to slowly degrade boxtier over time in another script
            countdownHandler.AddTImeToTimer(boxTier * 10);

            //Sets up next box
            boxHandler.BoxKilled();
            //Add score to score tracker
            sm.playerScore++;
        }
        else if (sm.playerScore >= 1)
        {
            countdownHandler.AddTImeToTimer(boxTier * 10);
            Instantiate(hitVFX,transform);
            boxHandler.BoxKilled();
            sm.playerScore++;
        }
        return;
    }

}
