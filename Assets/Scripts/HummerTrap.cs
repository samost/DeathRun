
using System.Collections;

using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class HummerTrap : Trap
{
    private Sequence _sequence;
    protected override IEnumerator Activate()
    {
        throw new System.NotImplementedException();
    }

    private float timeActivate;
    private float _timer = 0;
    private Tween _tween1;
    private Tween _tween2;
    

    private void MoveHummer()
    {
        _tween1 =  MoveableElements[0].DOLocalMoveZ(0.00035f, 2f).SetLoops(-1, LoopType.Yoyo).SetId("test").SetEase(Ease.Linear);
        _tween2 =  MoveableElements[2].DOLocalMoveX(13.13f, 2f).SetLoops(-1, LoopType.Yoyo).SetId("test").SetEase(Ease.Linear);
        
    }

    private IEnumerator HitHummer()
    {


        _tween1.Pause();
        _tween2.Pause();
        
        
        MoveableElements[1].DORotateQuaternion(Quaternion.Euler(-180, -90, 90), 0.5f).SetEase(Ease.InOutCubic).OnComplete
            ( (() => MoveableElements[1].DOPunchRotation(Vector3.right *-5f, 0.3f, 4,1)));
        

        yield return new WaitForSeconds(1f);
        
        MoveableElements[1].DORotateQuaternion(Quaternion.Euler(-90, -90, 90), 0.6f).SetEase(Ease.Linear);

        _tween1.Play();
        _tween2.Play();



    }

    private void Start()
    {
        timeActivate = Random.Range(2f, 3f);
        MoveHummer();
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= timeActivate)
        {
            StartCoroutine(HitHummer());
            timeActivate = Random.Range(2f, 3f);
            _timer = 0;
        }

        
    }
}
