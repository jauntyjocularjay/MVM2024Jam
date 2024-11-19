using UnityEditor.Animations;
using UnityEngine;

public class Button : MonoBehaviour
{
    public ButtonData data;
    SpriteRenderer buttonRenderer;
    public SpriteRenderer symbolRenderer;
    Animator buttonAnimator;

    void Start()
    {
        buttonRenderer = GetComponent<SpriteRenderer>();
        buttonAnimator = GetComponent<Animator>();

        buttonRenderer.sprite = data.button;
        buttonRenderer.color = data.color;

        symbolRenderer.sprite = data.symbol;
        symbolRenderer.color = data.color;
        
        buttonAnimator.runtimeAnimatorController = data.buttonAnimator;
    }


}
