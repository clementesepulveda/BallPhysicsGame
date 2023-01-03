using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public int spriteId;
    
    // TODO
    public string spriteType;
    //  public List<string> spriteTypes = {
    //     "ballSprite",
    //     "headSprite"
    //  }; 
     
    //  [Dropdown("spriteTypes")]//input the path of the list
    //  public string spriteType;

    public void OnMouseDown() {
        GameEvents.current.ButtonPress();
        Debug.Log($"SAVING SPRITE NUMBER {spriteId}");
        PlayerPrefs.SetString(spriteType, spriteId.ToString());
    }
}
