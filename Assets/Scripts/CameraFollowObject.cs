using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    [SerializeField] private Transform car; // Reference to the car's transform
    [SerializeField] private Vector3 relativePosition; // Relative position to the car

    private void LateUpdate()
    {
        if (car == null) return;

        // Match the camera's position to the car's position plus the relative offset
        // This keeps the camera at a fixed point relative to the car's position
        transform.position = car.TransformPoint(relativePosition);

        // Match the camera's rotation to the car's rotation
        // This ensures the camera's 'up' is always the car's 'up'
        transform.rotation = car.rotation;
    }
}
