
using UnityEngine;

public class MoveableStickman : MonoBehaviour
{
    [SerializeField] protected float Speed;
    protected new Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    protected virtual void Move()
    {
        
    }
}
