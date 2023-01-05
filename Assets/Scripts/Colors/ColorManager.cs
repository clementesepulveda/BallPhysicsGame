using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorManager : MonoBehaviour
{
    public Color color1;
    public Color color2;
    public Color color3;
    public Color color4;

    private Color[] defaultColors;
    
    // Start is called before the first frame update
    void Start() {
        defaultColors = new Color[]{color1, color2, color3, color4};
        CheckAndInstantiate();
        LocalSave();
        LoadColors();
    }

    void CheckAndInstantiate() {
        if (!PlayerPrefs.HasKey("Color1")) {
            InstantiateDefaultColors();
        }
    }

    void InstantiateDefaultColors() {
        PlayerPrefs.SetString("Color1", defaultColors[0].ToString());
        PlayerPrefs.SetString("Color2", defaultColors[1].ToString());
        PlayerPrefs.SetString("Color3", defaultColors[2].ToString());
        PlayerPrefs.SetString("Color4", defaultColors[3].ToString());
        PlayerPrefs.Save();
    }

    void LocalSave() {
        color1 = StringToColor(PlayerPrefs.GetString("Color1"));
        color2 = StringToColor(PlayerPrefs.GetString("Color2"));
        color3 = StringToColor(PlayerPrefs.GetString("Color3"));
        color4 = StringToColor(PlayerPrefs.GetString("Color4"));
    }

    public void LoadColors() {
        CheckAndInstantiate();
        LocalSave();

        Camera.main.backgroundColor = color2;

        Color[] colors = new Color[]{color1, color2, color3, color4};
        for (int i = 0; i < 4; i++) {
            SetImageColorWithTag(i, colors);
            SetSpriteColorWithTag(i, colors);
            SetTextColorWithTag(i, colors);
        }
    }

    Color StringToColor(string str_color) { 
        //Remove the header and brackets
        str_color = str_color.Replace("RGBA(", "");
        str_color = str_color.Replace(")", "");

        //Get the individual values (red green blue and alpha)
        var strings = str_color.Split(","[0] );

        Color outputcolor;
        outputcolor = Color.black;
        for (var i = 0; i < 4; i++) {
            outputcolor[i] = System.Single.Parse(strings[i]);
        }
        return outputcolor;
    }

    void SetImageColorWithTag(int colorIndex, Color[] colors) {
        GameObject[] _objects = GameObject.FindGameObjectsWithTag($"Color {colorIndex+1} Image");
        foreach(var _object in _objects) {
            _object.GetComponent<Image>().color = colors[colorIndex];
        }
    }

    void SetSpriteColorWithTag(int colorIndex, Color[] colors) {
        GameObject[] _objects = GameObject.FindGameObjectsWithTag($"Color {colorIndex+1} Sprite");
        foreach(var _object in _objects) {
            _object.GetComponent<SpriteRenderer>().color = colors[colorIndex];
        }
    }

    void SetTextColorWithTag(int colorIndex, Color[] colors) {
        GameObject[] _objects = GameObject.FindGameObjectsWithTag($"Color {colorIndex+1} Text");
        foreach(var _object in _objects) {
            _object.GetComponent<TMP_Text>().color = colors[colorIndex];
        }
    }

}