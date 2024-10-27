using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenarioLoader : MonoBehaviour
{
    // This script loads the scenarios when the buttons are clicked

    public void LoadScenario1() { SceneManager.LoadScene("Scenario1"); }

    public void LoadScenario2(){ SceneManager.LoadScene("Scenario2"); }

    public void LoadScenario3() { SceneManager.LoadScene("Scenario3"); }

    // Back to scenario selection scene (ScenarioScene)
    public void BackToScenarioScene() { SceneManager.LoadScene("ScenarioScene"); }
}
