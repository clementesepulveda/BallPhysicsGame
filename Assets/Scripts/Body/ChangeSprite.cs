using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ChangeSprite : MonoBehaviour
{
    public int spriteId;
    public string spriteType;
    public Image selector;

    void Start() {
        if (PlayerPrefs.GetInt(spriteType) == spriteId ) {
            selector.enabled = true;
        }
    }

    public void OnMouseDown() {
        GameEvents.current.ButtonPress();
        PlayerPrefs.SetInt(spriteType, spriteId);

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
