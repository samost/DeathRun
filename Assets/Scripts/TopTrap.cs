using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TopTrap : Trap
{
    private Tween _tween1;

    private float _timer;
    private float timeActivate;
    void Start()
    {
        _tween1 = MoveableElements[0].DOLocalMoveX(4.5f, 3f).SetLoops(-1, LoopType.Yoyo);
        
        timeActivate = Random.Range(3f, 4f);
    }

    
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= timeActivate)
        {
            StartCoroutine(Activate());
            timeActivate = Random.Range(3f, 4f);
            _timer = 0;
        }
    }

    protected override IEnumerator Activate()
    {
        _tween1.Pause();

        MoveableElements[0].DOLocalMoveY(11.42f, 0.7f).SetEase(Ease.InOutExpo);

        yield return new WaitForSeconds(1.2f);

        MoveableElements[0].DOLocalMoveY(18.8f, 0.7f).SetEase(Ease.Linear);
        
        _tween1.Play();
    }
}
