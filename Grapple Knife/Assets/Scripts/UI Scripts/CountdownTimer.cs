using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [Header("Countdown Vars")]
    [SerializeField] float timeRemaining = 10;
    [SerializeField] bool timerIsRunning = false;
    [SerializeField] float startDelay;
    public float totalGameLength;
    [Header("Refs")]
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] ScoreManager sm;
    [SerializeField] TextMeshProUGUI[] textDisabledOnStart;
    [SerializeField] ObjectiveDisplay[] objImgs;
    public UnityEvent endTimerEvent;

    //Secret var used to track time in level

    private void Awake()
    {
        sm = FindObjectOfType<ScoreManager>();

        foreach (TextMeshProUGUI obj in textDisabledOnStart)
        {
            obj.enabled = false;
        }

        timerText.enabled = false;
    }

    public void StartTimer()
    {
        foreach (TextMeshProUGUI obj in textDisabledOnStart)
        {
            obj.enabled = true;
        }

        timerText.enabled = true;

        //Sets timer text early to help emphasise total time
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        //Disable Obj Text
        foreach (ObjectiveDisplay objs in objImgs)
        {
            objs.DisableObjectiveObj(objs.targetObj);
        }

        //Clears player survial time and points, move to game manager
        sm.ResetScores();
        StartCoroutine(startDelayTest());
    }

    public void AddTImeToTimer(float addedTIme)
    {
        if (timerIsRunning)
        {
            timeRemaining += addedTIme;
            Debug.Log("Added " + addedTIme + "s to timer");
        }
        else
            return;
        
    }

    void Update()
    {
        if (timerIsRunning)
        {
            totalGameLength += Time.deltaTime;
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                sm.playerTime = totalGameLength;
                endTimerEvent.Invoke();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        //divides and multiplies float to ints to be turned into mins and secs
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public IEnumerator startDelayTest()
    {
        timerText.color = Color.grey;
        yield return new WaitForSeconds(startDelay);
        timerText.color = Color.white;
        timerIsRunning = true;
    }
}
