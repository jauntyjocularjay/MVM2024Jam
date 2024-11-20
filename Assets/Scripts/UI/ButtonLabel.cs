using UnityEditor.Animations;
using UnityEngine;

public class LabelButton : Button
{
    public LabelButtonData data;
    Animator buttonAnimator;

    void Start()
    {
        buttonRenderer = GetComponent<SpriteRenderer>();
        buttonAnimator = GetComponent<Animator>();

        buttonRenderer.sprite = data.button;

        symbolRenderer.sprite = data.symbol;
        symbolRenderer.color = buttonRenderer.color;
        
        buttonAnimator.runtimeAnimatorController = data.buttonAnimator;
    }


}
