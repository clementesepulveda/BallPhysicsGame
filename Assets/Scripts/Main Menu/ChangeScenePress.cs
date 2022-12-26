using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenePress : MonoBehaviour
{
    public string sceneToTransitionTo;

    void OnMouseDown() {
        TransitionToScene();
    }

    public void TransitionToScene() {
        GameEvents.current.ButtonPress();
        GameEvents.current.SceneLoad();

        Time.timeScale = 1; // TODO sketchy, might change
        SceneManager.LoadScene(sceneToTransitionTo);
    }
}
