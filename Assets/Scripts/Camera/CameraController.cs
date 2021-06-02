using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    [Range(1, 10)]
    [SerializeField] private float smoothFactor;

    private void FixedUpdate()
    {
        Follow();
    }

    /// <summary>
    /// Привязка камеры к персонажу
    /// </summary>
    private void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition =
            Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }
}
