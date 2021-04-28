using DG.Tweening;
using UnityEngine;

public class SpikesTrap : Trap
{

    private Sequence mySequence;
    private Tween tween;
   
    protected override void Activate()
   {
       DOTween.Restart("Activate");
   }

    protected override void Return()
    {
        
    }


    private void CreateSequence()
   {
       Tween tween ;
       for (int i = 0; i < MoveableElements.Count; i++)
       {
           tween = MoveableElements[i].DOLocalMoveY(-4.1f, 0.3f);
           mySequence.Append(tween);
       }for (int i = 0; i < MoveableElements.Count; i++)
       {
           tween = MoveableElements[i].DOLocalMoveY(-12.65f, 0.3f);
           mySequence.Append(tween);
       }

       mySequence.Pause();
       mySequence.SetId("Activate").SetAutoKill(false);
   }
   
   private void Start()
   {
       mySequence = DOTween.Sequence();
       CreateSequence();
       InvokeRepeating("Activate", 0, Random.Range(4, 6));
   }

  
}
