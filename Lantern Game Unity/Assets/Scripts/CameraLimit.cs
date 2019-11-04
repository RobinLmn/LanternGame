using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLimit : MonoBehaviour
{
    public CameraController CameraControllerScript;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MainCamera"))
        {
            Debug.Log("Collision");
            CameraControllerScript.EnterWall = true;
        }
    }
}