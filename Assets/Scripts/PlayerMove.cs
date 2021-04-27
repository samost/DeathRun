using UnityEngine;

public class PlayerMove : MoveableStickman
{
    
    protected override void Move()
    {
        if (Joystick.tap)
        {
            rigidbody.AddForce(Speed * Joystick.MoveDirection);
            
            Quaternion lookRotation =
                Joystick.MoveDirection != Vector3.zero ? Quaternion.LookRotation(Joystick.MoveDirection) : transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        }
        
        AnimatorController.Instance.SetRunAnimationPlayer(Joystick.tap);
    }
}
