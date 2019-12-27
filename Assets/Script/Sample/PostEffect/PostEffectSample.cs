using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;
using DG.Tweening;
using DamriTimelineLibrary;

public class PostEffectSample : BaseTimeControl
{
    public PostEffect postEffect;
    public Material postEffectMat;

    public float sigFactor = 5;

    float _HighIntensity;
    float _LowIntensity;
    float _CenterX;
    float _CenterY;

    protected override void SetupAction()
    {
        InitSequence();

        m_Sequence.Append(postEffectMat.DOFloat(sigFactor, "_HighIntensity", 5));
        m_Sequence.Join(postEffectMat.DOFloat(sigFactor, "_LowIntensity", 5));

        m_Sequence.Pause();
    }

    protected override void OnStart()
    {
        postEffect.Initialize(postEffectMat); 

        _HighIntensity = postEffectMat.GetFloat("_HighIntensity");
        _LowIntensity = postEffectMat.GetFloat("_LowIntensity");
        _CenterX = postEffectMat.GetFloat("_CenterX");
        _CenterY = postEffectMat.GetFloat("_CenterY");
    }

    protected override void OnEnd()
    {
        postEffectMat.SetFloat("_HighIntensity", _HighIntensity);
        postEffectMat.SetFloat("_LowIntensity", _LowIntensity);
        postEffectMat.SetFloat("_CenterX", _CenterX);
        postEffectMat.SetFloat("_CenterY", _CenterY);
    }
}
