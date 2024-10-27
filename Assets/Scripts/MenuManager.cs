using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    // In the main menu, for each button, corresponding scene will be loaded
    public void LoadStationaryObjectScene() { SceneManager.LoadScene("StationaryObjectScene"); }
    public void LoadAnimatedObjectScene() { SceneManager.LoadScene("AnimatedObjectScene"); }
    public void LoadMovingObjectScene() { SceneManager.LoadScene("MovingObjectScene"); }
    public void LoadObjectOnImageScene() { SceneManager.LoadScene("ObjectOnImageScene"); }
    public void LoadTextObjectScene() { SceneManager.LoadScene("TextObjectScene"); }
    public void LoadPlayVideoScene() { SceneManager.LoadScene("PlayVideoScene"); }
    public void LoadScenarioScene() { SceneManager.LoadScene("ScenarioScene"); }


    // For Back button, this function will be called 
    public void LoadMainMenu()
    {
        Debug.Log("Back button clicked!");
        SceneManager.LoadScene("SampleScene"); // Ana menü sahnenizin adı
    }
}
