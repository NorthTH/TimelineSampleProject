using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class MaterialPropertyPlayableBehaviour : PlayableBehaviour
{
    public string targetProperty { get; set;}
    public float startAlpha { get; set;}
    public float targetAlpha { get; set;}
    public AnimationCurve animationCurve {set;get;}

    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        
    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        
    }

    // Called each frame while the state is set to Play
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        var mat = playerData as Material;
        if(mat != null)
        {
            float duration = (float)playable.GetDuration();
            float time = (float)playable.GetTime();

            float inverseDuration = 1f / duration;
            float normalisedTime = time * inverseDuration;
            float progress = animationCurve.Evaluate(normalisedTime);

            float finalValue = Mathf.Lerp(startAlpha, targetAlpha, progress);

            mat.SetFloat(targetProperty, finalValue);
        }
    }
}
