using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;
using DG.Tweening;

public class TextTimelineManager : BaseTimeControl
{
    [Header("Main")]
    public TextSpaceController textSpacing;
    public float speed = 30;

    float moveWeight;

    protected override void SetupAction()
    {
        InitSequence();

        Sequence seq = m_Sequence;
        seq.Append(DOTween.To(() => textSpacing.moveWeight, (x) => textSpacing.moveWeight = x , textSpacing.moveWeight + speed, 1f).SetEase(Ease.Linear).SetLoops(int.MaxValue, LoopType.Incremental));

        seq.Pause();
    }

    protected override void OnStart()
    {
 
        moveWeight = textSpacing.moveWeight;
    }

    protected override void OnEnd()
    {
        textSpacing.moveWeight = moveWeight;
    }
}
