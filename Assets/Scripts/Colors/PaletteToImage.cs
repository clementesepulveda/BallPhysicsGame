using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaletteToImage : MonoBehaviour
{
    public int color;
    [SerializeField]
    private SaveColors Colors;

    void Start() {
        // TODO this looks like shit code
        if ( color == 1) {
            gameObject.GetComponent<Image>().color = Colors.color1;
        } else if (color == 2) {
            gameObject.GetComponent<Image>().color = Colors.color2;
        } else if (color == 3) {
            gameObject.GetComponent<Image>().color = Colors.color3;
        } else if (color == 4) {
            gameObject.GetComponent<Image>().color = Colors.color4;
        }
    }
}
