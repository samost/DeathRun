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

    private float _forcePlayer = 10f;
    private float _forceEnemy = 0;


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


            _player.GetComponent<PlayerMove>().liveState = false;             // for stop moved
            AnimatorController.Instance.SetRunAnimationPlayer(false);
            
            CameraController.Instance.SwapCam();

            _forcePlayer += _player.GetComponent<PlayerMove>().weaponHolder.GetWeaponForce();
        }

        if (other.CompareTag("Enemy"))
        {
            AddEnemy(other.gameObject);
            StartCoroutine(Wait(other.gameObject));
            
            _forceEnemy += other.gameObject.GetComponent<AIMove>().weaponHolder.GetWeaponForce();
            _forceEnemy += 1;
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

            //Debug.Log("test");
            
            Debug.Log(_forceEnemy);
            Debug.Log(_forcePlayer);
            
            yield return null;
        }
        
        //Debug.Log("Great!!!");
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
        
        DetermineWinner();
    }

    private IEnumerator PlayerLookAt()
    {
        while (true)
        {
            if (_enemys.Count == 0)
                yield break;
            
            
            _player.transform.LookAt(_enemys[0].transform.position);
            yield return null;
        }
    }

    private void DetermineWinner()
    {
        if (_forcePlayer >= _forceEnemy)
        {
            StartCoroutine(WinPlayerRoutine());
        }
        else
        {
            StartCoroutine(WinEnemyRoutine());
        }
    }

    private IEnumerator WinPlayerRoutine()
    {
        while (_enemys.Count != 0)
        {
            yield return new WaitForSeconds(2f);
            _enemys[0].GetComponent<AIMove>().Death();
            _enemys.RemoveAt(0);
        }
        
        yield break;
    }
    
    private IEnumerator WinEnemyRoutine()
    {
        yield return new WaitForSeconds(3f);
        _player.GetComponent<PlayerMove>().Death();
    }

    private IEnumerator Wait(GameObject o )
    {
        bool state = true;
        
        while (state)
        {
            if (_player == null)
            {
                yield return null;
            }
            else
            {
                StartBattle(o.gameObject);
                StartCoroutine(PlayerLookAt());
                AnimatorController.Instance.SetWeaponAnumationPlayer();
                _forceEnemy += 1;
                state = false;
            }
        }
        
        yield break;
    }
}
