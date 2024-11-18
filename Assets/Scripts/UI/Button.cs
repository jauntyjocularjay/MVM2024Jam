using UnityEditor.Animations;
using UnityEngine;

public class Button : MonoBehaviour
{
    public ButtonData data;
    SpriteRenderer spriteRenderer;
    Animator animator;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = data.sprite;

        
        animator = gameObject.GetComponent<Animator>();
        animator.runtimeAnimatorController = data.animatorController;
    }


}
