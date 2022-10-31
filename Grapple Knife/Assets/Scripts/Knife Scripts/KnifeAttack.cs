using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAttack : MonoBehaviour
{
    [SerializeField] LayerMask killableLayer;

    [Header("Knife References")]

    [SerializeField] Material knifeIndicatorMat;
    [SerializeField] Material knifeMat;
    [SerializeField] GameObject knifeMesh;
    [SerializeField] Animator animController;
    [SerializeField] GameObject playerBody;
    [SerializeField] GameObject camOrientation;

    [Header("Knife Vars")]

    [SerializeField, Range(0.01f, 1f)] float attackWindow;
    [SerializeField] float attackCooldown;
    [SerializeField] float attackAnimSpeed;
    [SerializeField] float rewardTime;
    private bool cooldownDone = true;

    [Header("Knife Dash Vars")]
    [SerializeField] float dashForce;
    [SerializeField] float dashUpwardForce;
    [SerializeField] bool usingGravity;

    public GameManager gm;
    [SerializeField] CountdownTimer cdTimer;
    private void Start()
    {
        animController.SetFloat("speedMultiplier", attackAnimSpeed);
    }

    #region Dash

    public void Dash()
    {
        Transform forwardT;
        forwardT = camOrientation.transform;

        Vector3 dashDirection = GetDirection(forwardT);

        Vector3 forcesToApply = dashDirection * dashForce + camOrientation.transform.up * dashUpwardForce;

        playerBody.GetComponent<Rigidbody>().AddForce(forcesToApply, ForceMode.Impulse);

        if (usingGravity)
            playerBody.GetComponent<Rigidbody>().useGravity = false;

        //Use this to delay script without coroutine
        Invoke(nameof(ResetDash), attackCooldown);
    }

    private void ResetDash()
    {
        if(usingGravity)
            playerBody.GetComponent<Rigidbody>().useGravity = true;
    }

    public Vector3 GetDirection(Transform forwardTransform)
    {
        //calculates and normalizes forward direction
        Vector3 direction = new Vector3();
        direction = forwardTransform.forward;

        return direction.normalized;
    }




    #endregion


    void Update()
    {
        if (gm.gameIsActive)
        {
            if ((Input.GetMouseButtonDown(1)) && cooldownDone == true)
            {
                StartAttack();
                AttackRecovery();
            }

        }
    }
    // detects if a collission happens with a certain tag, then destroys the knife box collission collided with
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Killable")
        {
            //  Debug.Log("Contacted Killable");
            //remove from knife, add to boxes
            cdTimer.AddTImeToTimer(rewardTime);
            Destroy(other.gameObject);
            Dash();
        }
    }

    void StartAttack()
    {
        GetComponent<BoxCollider>().enabled = true;
        knifeMesh.GetComponent<MeshRenderer>().material = knifeIndicatorMat;

        // starts both timers
        animController.SetTrigger("attackTrigger");
        StartCoroutine(AttackWindow());
    }

    void AttackRecovery()
    {
        cooldownDone = false;
        StartCoroutine(AttackCooldown());
    }

    #region Enumerators

    // Starts timer for how long the hurtbox is open for
    IEnumerator AttackWindow()
    {
        yield return new WaitForSeconds(attackWindow);
        GetComponent<BoxCollider>().enabled = false;
    }

    // Starts cooldown to prevent spamming of attacks
    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);

        knifeMesh.GetComponent<MeshRenderer>().material = knifeMat;
        animController.SetTrigger("attackTrigger");
        cooldownDone = true;
    }

    #endregion
}
