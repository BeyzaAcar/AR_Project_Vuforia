using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Renderer cubeRenderer;

    void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
    }

    public void ChangeCubeColor()
    {
        cubeRenderer.material.color = new Color(Random.value, Random.value, Random.value); // Change color to random color
    }
}
