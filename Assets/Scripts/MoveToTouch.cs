using UnityEngine;

// NOTE: this script works both for mouse and touch input on mobile devices 

/* CODE EXPLANATION :
    When a point with (x, y, z) coordinates is clicked, z is fixed to distanceFromCamera, 
    and x and y are calculated according to the screen position of the click, 
    then the object moves to that point with a speed of speed (that we can set in the inspector).
*/
public class MoveToTouch : MonoBehaviour
{
    private Camera mainCamera; // main camera
    private Vector3 targetPosition; // target position
    public float speed = 5f; // movement speed
    public float distanceFromCamera = 10f; // distance from camera

    void Start()
    {
        mainCamera = Camera.main; // Ana kamerayı referans olarak al

        // Check if the main camera is found
        if (mainCamera == null)
        {
            Debug.LogError("Main Camera not found!");
        }
        else 
        {
            Debug.Log("Main Camera found!");
        }

        targetPosition = transform.position; // Starting position
    }

    void Update()
    {
        // Check if the mouse is clicked or the screen is touched
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            // Get the input position of the mouse or touch 
            Vector3 inputPosition = Input.GetMouseButtonDown(0) ? Input.mousePosition : (Vector3)Input.GetTouch(0).position;

            // Convert screen position to world position and fix the z position
            targetPosition = mainCamera.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, distanceFromCamera));
            targetPosition.z = distanceFromCamera; // Fix the z position to distanceFromCamera
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
