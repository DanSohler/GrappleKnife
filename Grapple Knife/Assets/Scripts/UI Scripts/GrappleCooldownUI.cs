using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrappleCooldownUI : MonoBehaviour
{
    public GrapplingGun grappleScript;

    public float cooldownTimeRemaining;
    public Image fillMeter;


    private void Update()
    {
        if (grappleScript.grappleCooldown && grappleScript.isGrappling!)
        {
            cooldownTimeRemaining = grappleScript.grappleCooldownDelay;
            StartCoroutine(UiMeterFill(cooldownTimeRemaining));
        }

        Debug.Log(cooldownTimeRemaining);

    }

    public IEnumerator UiMeterFill(float cooldownTime)
    {
        if (cooldownTimeRemaining > 0)
        {
            cooldownTimeRemaining -= Time.deltaTime;
        }
        yield return new WaitForSeconds(cooldownTime);
    }
}
