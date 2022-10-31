using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSelect : MonoBehaviour
{
    public GrapplingGun grappleScript;
    public GameObject grappleObj;
    public GameObject knifeObj;
    public bool weaponType = false;

    public float swapDelay;

    private void Awake()
    {
        grappleObj.SetActive(true);
        knifeObj.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        SwapWeapon();
    }

    public void SwapWeapon()
    {
        if (Input.GetKey(KeyCode.Alpha1) && weaponType == true)
        {
            grappleObj.SetActive(true);
            grappleScript.grappleCooldown = true;
            StartCoroutine(SwapGrappleCooldown());
            knifeObj.SetActive(false);
            weaponType = false;
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            grappleScript.debugAssist.SetActive(false);
            grappleScript.StopGrapple();
            grappleScript.isGrappling = false;
            grappleObj.SetActive(false);
            knifeObj.SetActive(true);
            weaponType = true;
        }
    }
    public IEnumerator SwapGrappleCooldown()
    {
        yield return new WaitForSeconds(swapDelay);
        grappleScript.grappleCooldown = false;
    }
}
