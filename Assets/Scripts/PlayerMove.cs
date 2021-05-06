using System;
using DG.Tweening;
using UnityEngine;

public class PlayerMove : MoveableStickman
{
    [SerializeField] private float SpeedRotation;
    protected override void Move()
    {
        if (Joystick.tap)
        {
            rigidbody.AddForce(Speed * Joystick.MoveDirection, ForceMode.VelocityChange);

            Quaternion lookRotation =
                Joystick.MoveDirection != Vector3.zero ? Quaternion.LookRotation(Joystick.MoveDirection) : transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * SpeedRotation);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,0), Time.deltaTime * SpeedRotation);
        }

        AnimatorController.Instance.SetRunAnimationPlayer(Joystick.tap);
    }

    
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        
        if (other.CompareTag("Trap") && liveState)
        {
            Death();
        }
        
    }
    
    
}
