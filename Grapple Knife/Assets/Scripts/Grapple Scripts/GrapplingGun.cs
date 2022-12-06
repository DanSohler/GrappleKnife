using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class GrapplingGun : MonoBehaviour
{
    [Header("Grapple Logic")]
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    private LayerMask layerMask;

    public Transform gunTip, camera, player;
    [Header("Joint statistics")]
    private SpringJoint joint;
    public float jointSpring;
    public float jointDamper;
    public float jointMassScale;
    [Header("Grapple statistics")]
    public float maxDistance = 30f;
    public float grappleCooldownDelay;
    //temp var used to track distance, should be cleared whenever grapple is let go
    [SerializeField] private float jointCurrentDistance;

    //used for aim assist, rename
    [Header("Grapple Aim Assist")]
    public GameObject debugAssist;

    //flags for grapple restrictions
    [Header("Grapple Bools")]
    public bool isGrappling = false;
    public bool allowGrapple = false;
    public bool grappleCooldown;
    //used for ui

    [Header("Refs")]
    public GameManager gm;
    [SerializeField] GameObject vfxObj;

    [SerializeField] UnityEvent EndGrappleTutText;
    [SerializeField] UnityEvent EndReelTutText;

    void Awake()
    {
        debugAssist.SetActive(false);
    }

    void Update()
    {
        if (gm.gameIsActive)
        {
            if (Input.GetMouseButtonDown(0) && grappleCooldown == false && allowGrapple)
            {
                StartGrapple();
                grappleCooldown = true;
                isGrappling = true;

                bool firstGrapple = false;
                if (!firstGrapple)
                {
                    EndGrappleTutText.Invoke();
                    firstGrapple = true;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                StopGrapple();
                StartCoroutine(StartGrappleCooldown(grappleCooldownDelay));
                isGrappling = false;
                SetGrappleJointDistance(maxDistance);
            }


            RaycastHit hit;
            if (Physics.SphereCast(camera.position, 0.5f, camera.forward, out hit, maxDistance, whatIsGrappleable) && isGrappling == false && grappleCooldown == false)
            {
                debugAssist.SetActive(true);
                debugAssist.transform.position = hit.point;
                allowGrapple = true;
            }
            else
            {
                debugAssist.SetActive(false);
                allowGrapple = false;
            }


            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                if (isGrappling)
                {
                    joint.maxDistance = 0f;

                    bool firstReel = false;
                    if (!firstReel)
                    {
                        EndReelTutText.Invoke();
                        firstReel = true;
                    }
                }

            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                if (isGrappling)
                {
                    jointCurrentDistance = Vector3.Distance(gunTip.position, grapplePoint);
                    SetGrappleJointDistance(jointCurrentDistance);
                }
            }
        }

        
    }

    public void SpawnVFX(GameObject vfxObj, Vector3 vfxTransform)
    {
        Instantiate(vfxObj, vfxTransform, Quaternion.identity);
    }


    //time top make a func that can set the max distance, usable for when doing a reel
    public void SetGrappleJointDistance(float jointDistance)
    {
        if (joint != null)
        {
            joint.maxDistance = jointDistance;
        }
        else
        {
            return;
        }
    }

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
            SetGrappleJointDistance(distanceFromPoint * 0.8f); //Sets Max
;
            SpawnVFX(vfxObj, grapplePoint);
            joint.minDistance = 0f;

            joint.spring = jointSpring;
            joint.damper = jointDamper;
            joint.massScale = jointMassScale;
        }
    }

    public void StopGrapple()
    {
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

    public IEnumerator StartGrappleCooldown(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        grappleCooldown = false;
    }
}
