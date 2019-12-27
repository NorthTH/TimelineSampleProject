using System;
using UnityEngine;
using UnityEngine.Playables;

namespace DamriCustomTrack
{
    [Serializable]
    public class CanvasGroupPlayableBehaviour : PlayableBehaviour
    {
        public float startAlpha {set;get;}
        public float targetAlpha {set;get;}
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
            CanvasGroup canvasGroup = playerData as CanvasGroup;
 
            if (canvasGroup != null)
            {
                float duration = (float)playable.GetDuration();
                float time = (float)playable.GetTime();

                float inverseDuration = 1f / duration;
                float normalisedTime = time * inverseDuration;
                float progress = animationCurve.Evaluate(normalisedTime);

                float alpha = Mathf.Lerp(startAlpha, targetAlpha, progress);
                canvasGroup.alpha = alpha;
            }            
        }
    }
}