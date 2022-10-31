using UnityEngine;
using System.Collections;

public class GrapplingGun : MonoBehaviour
{
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    private LayerMask layerMask;

    public Transform gunTip, camera, player;
    private float maxDistance = 30f;

    private SpringJoint joint;
    public GameObject debugAssist;

    public bool isGrappling = false;
    public bool grappleCooldown;

    [Header("Grapple shot cooldown")]
    public float grappleTimeDelay;

    void Awake()
    {
        debugAssist.SetActive(false);
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && grappleCooldown == false)
        {
            StartGrapple();
            grappleCooldown = true;
            isGrappling = true;
        }

        else if (Input.GetMouseButtonUp(0))
        {
            StopGrapple();
            StartCoroutine(StartGrappleCooldown());
            isGrappling = false;
        }

        RaycastHit hit;
        if (Physics.SphereCast(camera.position, 0.5f, camera.forward, out hit, maxDistance, whatIsGrappleable) && isGrappling == false && grappleCooldown == false)
        {
            debugAssist.SetActive(true);
            debugAssist.transform.position = hit.point;
        }

        else
        {
            debugAssist.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            joint.maxDistance = 0f;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            joint.maxDistance = 30f; //put whatever you want the "normal" distance to be here -- the distance when not reeled in
        }

    }

    //Called after Update
    /* void LateUpdate()
     {
         DrawRope();
     } */

    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.SphereCast(camera.position, 0.5f, camera.forward, out hit, maxDistance, whatIsGrappleable))
        {

            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //The distance grapple will try to keep from grapple point.
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = 0f;

            //Adjust these values to fit your game.
            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            /*  lr.positionCount = 2; */

        }
    }


    /*  void DrawRope()
      {
          if (!joint) return;

          lr.SetPosition(0, gunTip.position);
          lr.SetPosition(1, grapplePoint);
      } */

    public void StopGrapple()
    {
        // lr.positionCount = 0;
        Destroy(joint);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }

    public IEnumerator StartGrappleCooldown()
    {
        yield return new WaitForSeconds(grappleTimeDelay);
        grappleCooldown = false;
    }
}
