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

    public void SetSpikesDeathAnimationPlayer()
    {
        _playerAnimator.SetTrigger("SpikesDeath");
    }

    public void SetHummerDeathAnimationPlayer()
    {
        _playerAnimator.SetTrigger("HummerDeath");
    }
    
    public void SetSpikesDeathAnimationAI(Animator anim)
    {
        anim.SetTrigger("SpikesDeath");
    }
     public void SetHummerDeathAnimationAI(Animator anim)
    {
        anim.SetTrigger("HummerDeath");
    }
    
    

    public void SetRunAnimationAI(float value,Animator anim)
    {
        bool state = value > 0 ? true : false;
        anim.SetBool("isRun", state);
    }
    
}
