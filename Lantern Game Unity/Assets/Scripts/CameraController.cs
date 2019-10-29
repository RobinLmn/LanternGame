using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    private Vector3 offset;

    public float zoomSpeed;
    public float minZoom;
    public float maxZoom;


    private float currentZoom = 1f;

    private void Start()
    {
        offset = transform.position - target.transform.position;
    }

    private void Update()
    {
        currentZoom -= Input.GetAxis("Vertical") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

    }

    private void LateUpdate()
    {
        transform.position = target.position + offset * currentZoom;

    }

}
