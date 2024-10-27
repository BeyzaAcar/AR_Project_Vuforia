using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public GameObject selectedObject; // Variable to store the selected object

    // Method to get the selected object
    public void SelectObject(GameObject obj)
    {
        if (selectedObject != null)
        {
            // Önceki seçili objeyi varsayılan rengine döndür
            SetColor(selectedObject, Color.white);
        }

        selectedObject = obj;
        // debug log
        Debug.Log("Selected object in selection manager: " + selectedObject.name);
        SetColor(selectedObject, Color.red); // Paint the selected object red 
    }

    // Method to set the color of an object (helper method)
    private void SetColor(GameObject obj, Color color)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = color;
        }
    }
}
