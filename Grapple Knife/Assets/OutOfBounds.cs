using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField] GameObject originPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            other.transform.position = originPoint.transform.position;
            Debug.Log("Caught player. sending to origin");
        }
    }
}
