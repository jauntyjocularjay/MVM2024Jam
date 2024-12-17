using System;
using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    private new SpriteRenderer renderer;
    public new Animation animation;
    public int animationClipsIndex;
    private Animator animator;
    public VFXLibrary library; // Use the VFX Scriptable Object you want to reference
    public string trigger; // Set the trigger you want to use
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

