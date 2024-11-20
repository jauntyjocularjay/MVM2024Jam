using UnityEditor.Animations;
using UnityEngine;

public class ToggleButton : Button
{
    public ToggleButtonData data;
    bool state = false;

    void Start()
    {
        buttonRenderer = GetComponent<SpriteRenderer>();

        symbolRenderer.sprite = data.symbolTrue;
        symbolRenderer.color = buttonRenderer.color;
    }


}
