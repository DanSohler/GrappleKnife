using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Reload Scene");
        SceneManager.LoadScene("Grapple Grid");
    }
}
