using UnityEditor.Animations;
using UnityEngine;

public class Button : MonoBehaviour
{
    public ButtonData data;
    SpriteRenderer buttonRenderer;
    public SpriteRenderer symbolRenderer;
    Color color = Color.magenta;
    Animator buttonAnimator;

    void Start()
    {
        buttonRenderer = GetComponent<SpriteRenderer>();
        buttonAnimator = GetComponent<Animator>();

        buttonRenderer.sprite = data.button;
        buttonRenderer.color = color;

        symbolRenderer.sprite = data.symbol;
        symbolRenderer.color = color;
        
        buttonAnimator.runtimeAnimatorController = data.buttonAnimator;
    }


}
