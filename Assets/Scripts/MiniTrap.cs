using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MiniTrap : Trap
{
    
    void Start()
    {
        MoveableElements[0].DORotateQuaternion(Quaternion.Euler(-180, -90, 0), 1f).SetEase(Ease.InOutCubic)
            .SetLoops(-1, LoopType.Yoyo);
    }

    protected override IEnumerator Activate()
    {
        throw new System.NotImplementedException();
    }
}
