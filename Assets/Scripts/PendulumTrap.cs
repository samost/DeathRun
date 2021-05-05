using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PendulumTrap : Trap
{

    private void Start()
    {
        MoveableElements[0].DORotateQuaternion(Quaternion.Euler(0, 0, 90), 2.3f).SetEase(Ease.InOutCubic).SetLoops(-1, LoopType.Yoyo);
        
        
    }

    protected override IEnumerator Activate()
    {
        throw new NotImplementedException();
    }
}
