using UnityEngine;

public class RotationManager : MonoBehaviour
{
    public GameObject selectedObject; // This will store the current selected object

    public void RotateX()
    {
        if (selectedObject != null)
        {
            selectedObject.transform.Rotate(Vector3.right * 10f); // Rotate around X-axis
        }
        else
        {
            Debug.LogError("No object selected to rotate on X-axis!");
        }
    }

    public void RotateY()
    {
        if (selectedObject != null)
        {
            selectedObject.transform.Rotate(Vector3.up * 10f); // Rotate around Y-axis
        }
        else
        {
            Debug.LogError("No object selected to rotate on Y-axis!");
        }
    }

    public void RotateZ()
    {
        if (selectedObject != null)
        {
            selectedObject.transform.Rotate(Vector3.forward * 10f); // Rotate around Z-axis
        }
        else
        {
            Debug.LogError("No object selected to rotate on Z-axis!");
        }
    }
}
