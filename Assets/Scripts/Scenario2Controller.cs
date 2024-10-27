using UnityEngine;

public class Scenario2Controller : MonoBehaviour
{
    public SelectionManager selectionManager; // Reference to the SelectionManager
    public RotationManager rotationManager;   // Reference to the RotationManager

    void Update()
    {
        // Check for mouse click or touch
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Vector3 inputPosition = Input.GetMouseButtonDown(0) ? Input.mousePosition : (Vector3)Input.GetTouch(0).position;
            Ray ray = Camera.main.ScreenPointToRay(inputPosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    selectionManager.SelectObject(hit.collider.gameObject); // Select the object
                    rotationManager.selectedObject = selectionManager.selectedObject; // Pass selected object to RotationManager
                }
            }
        }
    }

    public void RotateXButton() => rotationManager.RotateX();
    public void RotateYButton() => rotationManager.RotateY();
    public void RotateZButton() => rotationManager.RotateZ();
}
