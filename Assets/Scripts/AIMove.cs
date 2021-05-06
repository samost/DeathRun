using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

public class AIMove : MoveableStickman
{
    [SerializeField] private PathFollower _pathFollower;
    private bool isImmortal = false;
    
    private bool isWait = false;
    
    private GameObject _targetPlayer;
    private bool _isTargetPlayerNotNull;

    protected override void Move()
    {
        _pathFollower.speed = Speed;
        AnimatorController.Instance.SetRunAnimationAI(Speed, Animator);
        
    }

    protected override void Start()
    {
        _isTargetPlayerNotNull = _targetPlayer != null;
        base.Start();
        _targetPlayer = GameObject.FindGameObjectWithTag("Player");
        
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        isImmortal =
            (Vector3.Distance(_targetPlayer.transform.position, transform.position) > 11 &&
             _targetPlayer.transform.position.z > transform.position.z)
                ? true
                : false;
    }


    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        
        if (other.CompareTag("Trap") && liveState && !isImmortal)
        {
            Death();
            StopPathFollower();
        }

        if (other.CompareTag("PreTrap") && !isWait)
        {
            int rand = Random.Range(0, 1);
            if (rand == 0)
            {
                StartCoroutine(Wait(Random.Range(1f, 1.5f)));
            }
            
        }
        
        if (other.CompareTag("PreTrapMaytnik") && !isWait)
        {
            int rand = Random.Range(0, 1);
            if (rand == 0)
            {
                StartCoroutine(Wait(0.5f));
            }
            
        }
    }

    private IEnumerator Wait(float time)
    {
        isWait = true;
        
        float tempSpeed = Speed;
        Speed = 0;
        
        yield return new WaitForSeconds(time);
        
        Speed = tempSpeed;
        isWait = false;
    }

    public void StopPathFollower()
    {
        Speed = 0;
        _pathFollower.enabled = false;
    }
}
