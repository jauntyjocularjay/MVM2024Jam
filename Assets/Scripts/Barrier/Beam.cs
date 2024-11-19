using Unity.VisualScripting;
using UnityEngine;

public class Beam : MonoBehaviour
{
    SpriteRenderer[] renderers;
    BoxCollider2D[] colliders;
    Animator[] animators;
    float increment = 1.0f/128.0f;

    void Start()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>();
        colliders = GetComponentsInChildren<BoxCollider2D>();
    }
    void Update()
    {}
    public void Deactivate()
    {
        // beam falters and disappears
        foreach(Animator animator in animators)
        {
            animator.SetTrigger("death");
        }
    }
}
