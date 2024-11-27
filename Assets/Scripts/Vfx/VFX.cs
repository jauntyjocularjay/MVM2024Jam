using System.Collections.Generic;
using UnityEngine;

public class VFX : MonoBehaviour
{
    public VFXLibrary data;
    Animator animator;
    public List<string> triggers;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = data.animatorController;

        triggers = data.triggers;
    }
}

