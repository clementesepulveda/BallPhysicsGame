using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveColors : MonoBehaviour
{
    public GameObject ColorManager;

    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;
    
    public void ChangePalletButton() {
        GameEvents.current.ButtonPress();
        ChangePallet();
    }

    public void ChangePallet() {
        PlayerPrefs.SetString("Color1", color1.ToString());
        PlayerPrefs.SetString("Color2", color2.ToString());
        PlayerPrefs.SetString("Color3", color3.ToString());
        PlayerPrefs.SetString("Color4", color4.ToString());
        PlayerPrefs.Save();

        ColorManager.GetComponent<ColorManager>().LoadColors();
    }

    void OnMouseDown() {
        Debug.Log("yooo");
    }
}
