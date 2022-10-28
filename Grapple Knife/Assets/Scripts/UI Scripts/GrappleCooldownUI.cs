using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrappleCooldownUI : MonoBehaviour
{
    public GrapplingGun grappleScript;

    public float cooldownTimeRemaining;
    public Image fillMeter;

    private void Start()
    {
        cooldownTimeRemaining = grappleScript.grappleCooldownDelay;
    }


    private void Update()
    {
        if (grappleScript.grappleCooldown && grappleScript.isGrappling!)
        {
            ReduceFillMeter();
        }
    }

    private void ReduceFillMeter()
    {
        if (cooldownTimeRemaining > 0)
        {
            cooldownTimeRemaining -= Time.deltaTime;
            fillMeter.fillAmount -= cooldownTimeRemaining * Time.deltaTime;
        }
        
    }

    private void CheckIfNotGrappling()
    {
        if (grappleScript.isGrappling!)
        {
            cooldownTimeRemaining = grappleScript.grappleCooldownDelay;
        }

    }
}
