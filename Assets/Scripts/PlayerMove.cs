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
        
        AnimatorController.Instance.SetRunAnimationPlayer(Joystick.tap);
    }
}
