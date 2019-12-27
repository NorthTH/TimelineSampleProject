using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;
using DG.Tweening;
using DamriTimelineLibrary;

public class DotweenOnTimelineSample : BaseTimeControl
{
    public Image image;

    Color defaultColor;

    protected override void SetupAction()
    {
        InitSequence();

        m_Sequence.Append( image.DOColor(Color.red, 3) );
        m_Sequence.Append( image.DOColor(Color.green, 3) );

        m_Sequence.Pause();
    }

    protected override void OnStart()
    {
        if(image != null)
            defaultColor = image.color;
    }

    protected override void OnEnd()
    {
        if(image != null)
            image.color = defaultColor;
    }
}
