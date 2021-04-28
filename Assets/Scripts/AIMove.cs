using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

public class AIMove : MoveableStickman
{
    [SerializeField] private PathFollower _pathFollower;
    
    
    protected override void Move()
    {
        _pathFollower.speed = Speed;
        AnimatorController.Instance.SetRunAnimationAI(Speed);
    }
}
