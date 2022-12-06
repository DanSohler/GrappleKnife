using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitMarker : MonoBehaviour
{
    [SerializeField] Image hitMarkerObj;


    private void Start()
    {
        hitMarkerObj.enabled = false;
    }
    public void EnableHitMarker()
    {
        hitMarkerObj.enabled = true;
        Invoke(nameof(DisableHitMarker), 0.25f);
    }

    private void DisableHitMarker()
    {
        hitMarkerObj.enabled = false;
    }
}
