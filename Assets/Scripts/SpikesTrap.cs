using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpikesTrap : Trap
{
    private Sequence mySequence;
    
    private float _timer;

    private float timeActivate;

    protected override IEnumerator Activate()
    {
        int randNum = Random.Range(0, MoveableElements.Count);
        
        MoveableElements[randNum].DOLocalMoveY(-4.1f, 0.3f);

        yield return new WaitForSeconds(1f);
        
        MoveableElements[randNum].DOLocalMoveY(-17.3f, 0.3f);
        
    }

    private void Start()
    {
        timeActivate = 0.5f;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= timeActivate)
        {
            StartCoroutine(Activate());
            timeActivate = Random.Range(3f, 4f);
            _timer = 0;
        }
    }
}