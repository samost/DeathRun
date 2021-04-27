using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    
    [SerializeField] private Animator _playerAnimator;

    public static AnimatorController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SetRunAnimationPlayer(bool state)
    {
        _playerAnimator.SetBool("isRun", state);
    }
}
