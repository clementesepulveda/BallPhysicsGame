using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenePress : MonoBehaviour
{
    public string sceneToTransitionTo;
    public Animator transition;
    public int transitionFrames = 15;

    void OnMouseDown() {
        TransitionToScene();
    }

    public void TransitionToScene() {
        TransitionStart();
        SceneManager.LoadScene(sceneToTransitionTo);
    }

    public void TransitionWithAnimator() {
        TransitionStart();
        StartCoroutine(LoadLevel());
    }

    private void TransitionStart() {
        GameEvents.current.ButtonPress();
        GameEvents.current.SceneLoad();

        Time.timeScale = 1; // TODO sketchy, might change
    }

    IEnumerator LoadLevel() {
        transition.SetTrigger("Start");

        float waitFrames = Time.deltaTime * transitionFrames;
        yield return new WaitForSeconds(waitFrames);
        
        SceneManager.LoadScene(sceneToTransitionTo);
    }
}
