using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationStates { public const string Death = nameof(Death); }

[RequireComponent(typeof(Animator))]
public class HeroDeath : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Death()
    {
        _animator.SetTrigger(AnimationStates.Death);
    }
}
