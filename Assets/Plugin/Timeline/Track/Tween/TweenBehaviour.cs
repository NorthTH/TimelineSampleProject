using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Tween
{
    [Serializable]
    public class TweenBehaviour : PlayableBehaviour
    {

        // public float inverseDuration;
        public TweenVector3 position;
        public TweenVector3 rotation;
        public TweenVector3 scale;

        public override void OnGraphStart(Playable playable)
        {
            // double duration = playable.GetDuration();
            // if (Mathf.Approximately((float)duration, 0f))
            //     throw new UnityException("A TransformTween cannot have a duration of zero.");

            // inverseDuration = 1f / (float)duration;
        }
    }

    [Serializable]
    public class TweenVector3
    {
        public Vector3 startOffSet;
        public Vector3 endOffSet;
        public AnimationCurve currentCurve = AnimationCurve.Linear(0,1,1,1);
    }
}