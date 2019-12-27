using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class MaterialPropertyPlayableAsset : PlayableAsset
{
    public string targetProperty;
    public float startValue;
    public float targetValue;
    public AnimationCurve animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        var playable = ScriptPlayable<MaterialPropertyPlayableBehaviour>.Create(graph);

        var resumePlayableBehaviour = playable.GetBehaviour();
        resumePlayableBehaviour.targetProperty = targetProperty;
        resumePlayableBehaviour.startAlpha = startValue;
        resumePlayableBehaviour.targetAlpha = targetValue;
        resumePlayableBehaviour.animationCurve = animationCurve;
        
        return playable;
    }
}
