using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Animator _AIAnimator;

    public static AnimatorController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SetRunAnimationPlayer(bool state)
    {
        _playerAnimator.SetBool("isRun", state);
    }

    public void SetRunAnimationAI(float value)
    {
        bool state = value >= 0 ? true : false;
        _AIAnimator.SetBool("isRun", state);
    }
}
