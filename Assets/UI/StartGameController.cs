using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StartGameController : MonoBehaviour
{

    private List<GameObject> enemys;
    [SerializeField] private Image finger;
    [SerializeField] private Image line;
    [SerializeField] private GameObject BarUI;

    private float oldSpeed;
    
    void Start()
    {
        enemys = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        foreach (var enemy in enemys)
        {
            var o = enemy.GetComponent<AIMove>();
            oldSpeed = o.GetSpeed();
            o.SetSpeed(0);
        }

        finger.rectTransform.DOAnchorPosX(200, 1.3f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        
        
        line.rectTransform.DOScale(new Vector3(1.1f,1.1f,1.1f), 0.3f).SetLoops(-1, LoopType.Yoyo);

    }

    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (var enemy in enemys)
            {
                var o = enemy.GetComponent<AIMove>();
                o.SetSpeed(oldSpeed);
            }
            BarUI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
