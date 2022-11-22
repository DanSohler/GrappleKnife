using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveDisplay : MonoBehaviour
{
    public GameObject targetObj;
    [SerializeField] UIFadeLerp fadeScript;
    [SerializeField] float waitTime;

    //Just meant to show player obj at start of game

    public void DisableObjectiveObj(GameObject someObj)
    {
        StartCoroutine(DelayedDisable(someObj, waitTime));
    }

    public IEnumerator DelayedDisable(GameObject targetedObj, float startDelay)
    {
        yield return new WaitForSeconds(startDelay);
        //Just affects UI art
        StartCoroutine(fadeScript.UIElementFade(targetedObj.GetComponent<Image>(), targetedObj.GetComponentInChildren<TMP_Text>(), 0f, 0.125f, false));
        //Just effects text
        StartCoroutine(fadeScript.UIElementFade(targetedObj.GetComponent<Image>(), targetedObj.GetComponentInChildren<TMP_Text>(), 0f, 0.125f, true));
        //fuckinobj.SetActive(false);
    }
}
