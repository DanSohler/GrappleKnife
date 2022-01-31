using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSelect : MonoBehaviour
{
    public GrapplingGun grappleScript;
    public GameObject grappleObj;
    public GameObject knifeObj;

    private void Awake()
    {
        grappleObj.SetActive(true);
        knifeObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            grappleObj.SetActive(true);
            grappleScript.grappleCooldown = true;
            StartCoroutine(SwapGrappleCooldown());
            knifeObj.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            grappleScript.debugAssist.SetActive(false);
            grappleScript.StopGrapple();
            grappleScript.isGrappling = false;

            grappleObj.SetActive(false);
            knifeObj.SetActive(true);
        }

    }

    public IEnumerator SwapGrappleCooldown()
    {
        yield return new WaitForSeconds(1.5f);
        grappleScript.grappleCooldown = false;
    }
}
