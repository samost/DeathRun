using System;
using System.Collections;
using System.Collections.Generic;
using Bolt;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class BattleController : MonoBehaviour
{
    private List<GameObject> _enemys;
    private GameObject _player;
    

    private Transform _target;

    private float _forcePlayer = 10f;
    private float _forceEnemy = 0f;

    public static List<GameObject> _enemysCount;

    [SerializeField] private GameObject ui_result;
    [SerializeField] private GameObject uiBar;


    private void Start()
    {
        _enemys = new List<GameObject>();
        
        _enemysCount = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiBar.SetActive(false);
            
            _player = other.gameObject;
            StartCoroutine(CheckEnemysCorutine());


            var o = _player.GetComponent<PlayerMove>();
            o.liveState = false;                                 // for stop moved
            o.isFinishDeath = true;
            
            AnimatorController.Instance.SetRunAnimationPlayer(false);
            
            CameraController.Instance.SwapCam();

            _forcePlayer += o.weaponHolder.GetWeaponForce();
        }

        if (other.CompareTag("Enemy"))
        {
            AddEnemy(other.gameObject);
            //StartCoroutine(Wait(other.gameObject));
            
            _forceEnemy += other.gameObject.GetComponent<AIMove>().weaponHolder.GetWeaponForce();
            _forceEnemy += 1;
        }
    }

    IEnumerator CheckEnemysCorutine()
    {
        while (_enemysCount.Count != _enemys.Count)
        {
            yield return null;
        }
        
        StartBattle();
    }
    

    private void AddEnemy(GameObject o)
    {
        o.GetComponent<AIMove>().StopPathFollower();
        _enemys.Add(o);
    }

    private void StartBattle()
    {
        StartCoroutine(PlayerLookAt());
        
        AnimatorController.Instance.SetWeaponAnimationPlayer(_player.GetComponent<PlayerMove>().isWeapon);
        
        NavMeshAgent navMeshAgent;
        
        for (int i = 0; i < _enemys.Count; i++)
        {
            navMeshAgent = _enemys[i].GetComponent<NavMeshAgent>();
            navMeshAgent.enabled = true;
            navMeshAgent.SetDestination(_player.transform.position);
            _enemys[i].transform.LookAt(_player.transform);
            
            AnimatorController.Instance.SetWeaponAnimationAI(_enemys[i].GetComponent<Animator>(), _enemys[i].GetComponent<AIMove>().isWeapon);
        }
        
        DetermineWinner();
    }

    private IEnumerator PlayerLookAt()
    {

        while (_enemys.Count != 0)
        {
            _player.transform.LookAt(_enemys[0].transform.position);
            yield return null;
        }
        
        _player.transform.LookAt(null);
        yield break;
    }

    private void DetermineWinner()
    {
        Debug.Log(_forceEnemy);
        Debug.Log(_forcePlayer);
        
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
        
        StopAllCoroutines();
        
        CustomEvent.Trigger(ui_result, "result_play", 1, 2);
        yield break;
        
    }
    
    private IEnumerator WinEnemyRoutine()
    {
        yield return new WaitForSeconds(3f);
        _player.GetComponent<PlayerMove>().Death();
        
        CustomEvent.Trigger(ui_result, "result_play", 1, 2);
        StopAllCoroutines();
    }
}
