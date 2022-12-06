using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempObj : MonoBehaviour
{
    private void Awake()
    {
        Invoke("DestroySelf", 2f);
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}
