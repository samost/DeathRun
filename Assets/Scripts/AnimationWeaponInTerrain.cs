using DG.Tweening;
using UnityEngine;

public class AnimationWeaponInTerrain : MonoBehaviour
{
    private void Start()
    {
        gameObject.transform.DOPunchScale(Vector3.one * 0.3f, 1.5f, 0, 0).SetLoops(-1, LoopType.Restart);
    }
}
