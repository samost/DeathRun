using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class BattleController : MonoBehaviour
{
    private List<GameObject> _enemys;
    private GameObject _player;
    
    private bool StateCheckCourutine = true;

    private Transform _target;

    private bool isFight = false;


    private void Start()
    {
        _enemys = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CheckEnemysCorutine());
            _player = other.gameObject;
            
            _player.GetComponent<PlayerMove>().liveState = false;
            AnimatorController.Instance.SetRunAnimationPlayer(false);
            
        }

        if (other.CompareTag("Enemy"))
        {
            StateCheckCourutine = false;
            
            AddEnemy(other.gameObject);
            StartBattle(other.gameObject);
            StartCoroutine(PlayerLookAt());
            AnimatorController.Instance.SetWeaponAnumationPlayer();
        }
    }

    IEnumerator CheckEnemysCorutine()
    {
        while (StateCheckCourutine)
        {
            GameObject[] countEnemyLive = GameObject.FindGameObjectsWithTag("Enemy");

            if (countEnemyLive.Length == 0)
            {
                StateCheckCourutine = false;
            }

            Debug.Log("test");
            
            yield return null;
        }
        
        Debug.Log("Great!!!");
        yield break;
    }
    

    private void AddEnemy(GameObject o)
    {
        o.GetComponent<AIMove>().StopPathFollower();
        _enemys.Add(o);
    }

    private void StartBattle(GameObject o)
    {
        NavMeshAgent navMeshAgent = o.GetComponent<NavMeshAgent>();
        navMeshAgent.enabled = true;
        navMeshAgent.SetDestination(_player.transform.position);
        o.transform.LookAt(_player.transform);
        AnimatorController.Instance.SetWeaponAnimationAI(o.GetComponent<Animator>());
    }

    private IEnumerator PlayerLookAt()
    {
        while (true)
        {
            _player.transform.LookAt(_enemys[0].transform.position);
            yield return null;
        }
    }
}
