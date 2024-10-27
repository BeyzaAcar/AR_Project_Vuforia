using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float rotationSpeed = 0f; // Default rotation speed

    void Update()
    {
        if (rotationSpeed != 0)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime); // Rotate around y-axis
        }
    }

    public void ToggleRotation()
    {
        rotationSpeed = (rotationSpeed == 0) ? 50f : 0f; // Toggle rotation speed
    }
}
