using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreYouSure : MonoBehaviour
{
    public GameObject parentObject;
    
    public void HideObject() {
        GameEvents.current.ButtonPress();
        parentObject.SetActive(false);
    }
    public void ShowObject() {
        GameEvents.current.ButtonPress();
        parentObject.SetActive(true);

        // TODO feels half assed
        GameObject.FindGameObjectWithTag($"Color Manager").GetComponent<ColorManager>().LoadColors();
    }
}
