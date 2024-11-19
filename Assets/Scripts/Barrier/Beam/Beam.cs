using Unity.VisualScripting;
using UnityEngine;

public class Beam : MonoBehaviour
{
    SpriteRenderer[] renderers;
    BoxCollider2D[] colliders;
    Animator[] animators;

    void Start()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>();
        colliders = GetComponentsInChildren<BoxCollider2D>();
        animators = GetComponentsInChildren<Animator>();
    }
    void Update()
    {}
    public void Deactivate()
    {
        foreach(BoxCollider2D collider in colliders)
        {
            collider.size = Vector2.zero;
        }
        // beam falters and disappears
        foreach(Animator animator in animators)
        {
            animator.SetTrigger("death");
        }
    }
}
