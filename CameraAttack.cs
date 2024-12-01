using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAttack : MonoBehaviour
{
    public Transform target;              // The target to focus on (player object)
    public float zoomSpeed = 5.0f;        // Speed at which camera zooms in
    public Vector3 zoomDistances;         // Desired distances from the target along each axis

    private Vector3 initialPosition;      // Initial position of the camera
    private bool isZooming = false;       // Flag to check if camera is currently zooming

    private void Start()
    {
        initialPosition = transform.position;
    }

    public void ZoomToTarget()
    {
        if (isZooming || target == null)
            return;

        StartCoroutine(ZoomCoroutine());
    }

    private IEnumerator ZoomCoroutine()
    {
        isZooming = true;

        Vector3 targetPosition = target.position +
                                 new Vector3(zoomDistances.x, zoomDistances.y, zoomDistances.z);

        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * zoomSpeed);
            yield return null;
        }

        isZooming = false;
    }

    public void ResetZoom()
    {
        if (isZooming)
            StopAllCoroutines();

        transform.position = initialPosition;
        isZooming = false;
    }
}




