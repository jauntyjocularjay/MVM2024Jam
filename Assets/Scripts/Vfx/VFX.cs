using UnityEngine;

public class VFX : MonoBehaviour
{
    private new SpriteRenderer renderer;
    public new Animation animation;
    private Animator animator;
    public VFXLibrary library;
    public string trigger;
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        animation = GetComponent<Animation>();
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = library.animatorController;
    }
    public void Play()
    {
        animator.SetTrigger(trigger);
    }
    public void Stop()
    {
        animator.SetTrigger("idle");
    }

}

