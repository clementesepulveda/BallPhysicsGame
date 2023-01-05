using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SaveColors : MonoBehaviour
{
    public GameObject ColorManager;
    public Image selector;

    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;

    void Start() {
        var c1 = PlayerPrefs.GetString("Color1") == color1.ToString();
        var c2 = PlayerPrefs.GetString("Color2") == color2.ToString();
        var c3 = PlayerPrefs.GetString("Color3") == color3.ToString();
        var c4 = PlayerPrefs.GetString("Color4") == color4.ToString();
        if ( c1 && c2 && c3 && c4 ) {
            selector.enabled = true;
        }
    }
    
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

        DisableTheRestOfSelectors();
        selector.enabled = true;
    }

    private void DisableTheRestOfSelectors() {
        var objects = Resources.FindObjectsOfTypeAll<Image>().Where(
            obj => obj.name == "Selector" && obj.gameObject.activeInHierarchy
        );

        foreach (var object_ in objects){
            object_.enabled = false;    
        }
    }
}
