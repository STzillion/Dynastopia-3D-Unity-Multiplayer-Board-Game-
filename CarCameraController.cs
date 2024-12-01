using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCameraController : MonoBehaviour
{
    public Transform target;
    public float distance = 1.5f;
    public float height = 0.5f;
    public float offset = -1.4f;
    public float smoothSpeed = 2.0f;

   

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isZoomed = false; // New flag to track zoom state

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the new camera position
            Vector3 offsetDir = (target.forward - target.right).normalized;

            // Use the targetPosition when zoomed, otherwise calculate normal position
            Vector3 newPosition = isZoomed ? targetPosition : target.position - (offsetDir * offset) + (target.up * height) - (target.forward * distance);

            // Calculate the new camera rotation
            Quaternion newRotation = Quaternion.LookRotation(target.position - newPosition, Vector3.up);

            // Set the camera position and rotation using a smooth interpolation
            transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, smoothSpeed * Time.deltaTime);
        }
    }

  

    public void ZoomIn(Vector3 zoomDistances)
    {
        if (isZoomed || target == null)
            return;

        targetPosition = target.position + zoomDistances;
        isZoomed = true;
    }

    public void ResetZoom()
    {
        isZoomed = false;
    }

   
}



