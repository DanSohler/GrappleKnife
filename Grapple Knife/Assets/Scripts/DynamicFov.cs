using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicFov : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] float baseFOV;
    [SerializeField] Rigidbody playerBody;

    private void Awake()
    {
        mainCam = GetComponent<Camera>();
    }
    private void Start()
    {
        baseFOV = mainCam.fieldOfView;
        mainCam.fieldOfView = baseFOV;
    }

    private void Update()
    {
        //When momentum goes above x, make fov scale with it

        mainCam.fieldOfView = playerBody.velocity.magnitude + 60;


  /*      if (playerBody.velocity.magnitude >= 18)
        {
            mainCam.fieldOfView = playerBody.velocity.magnitude + 42;
        }
        else
        {
            
        }
*/
      }
}
