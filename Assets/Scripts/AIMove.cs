using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

public class AIMove : MoveableStickman
{
    [SerializeField] private PathFollower _pathFollower;
    private bool isImmortal = false;
    
    private GameObject _targetPlayer;
    
    protected override void Move()
    {
        _pathFollower.speed = Speed;
        AnimatorController.Instance.SetRunAnimationAI(Speed, Animator);
        
    }

    protected override void Start()
    {
        base.Start();
        _targetPlayer = GameObject.FindGameObjectWithTag("Player");
        
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        isImmortal = (Vector3.Distance(_targetPlayer.transform.position, transform.position) > 13 && _targetPlayer.transform.position.z > transform.position.z) ? true : false;
    }


    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        
        if (other.CompareTag("Trap") && liveState && !isImmortal)
        {
            Death();
            StopPathFollower();
        }

        if (other.CompareTag("PreTrap"))
        {
            int rand = Random.Range(0, 2);
            if (rand == 0)
            {
                StartCoroutine(Wait());
            }
            
        }
    }

    private IEnumerator Wait()
    {
        float tempSpeed = Speed;
        Speed = 0;
        
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        
        Speed = tempSpeed;
    }

    private void StopPathFollower()
    {
        _pathFollower.speed = 0;
    }
}
