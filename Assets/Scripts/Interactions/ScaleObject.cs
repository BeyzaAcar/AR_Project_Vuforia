using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    private bool isScaledUp = false;
    // Take the cube's first scale to reset it later
    private Vector3 initialScale;
    public void ToggleScale()
    {
        if (isScaledUp)
        {
            transform.localScale = initialScale; // Reset the scale
        }
        else
        {
            initialScale = transform.localScale; // Save the initial scale
            transform.localScale *= 1.5f; // Scale the cube by 1.5
        }
        isScaledUp = !isScaledUp; // Toggle scale state 
    }
}
