using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

namespace DamriCustomTrack
{
    [System.Serializable]
    public class RawImagePlayableBehaviour : PlayableBehaviour
    {
        public Color startColor {set;get;}
        public Color targetColor {set;get;}
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
            RawImage image = playerData as RawImage;
 
            if (image != null)
            {
                float duration = (float)playable.GetDuration();
                float time = (float)playable.GetTime();

                float inverseDuration = 1f / duration;
                float normalisedTime = time * inverseDuration;
                float progress = animationCurve.Evaluate(normalisedTime);

                float finalR = Mathf.Lerp(startColor.r, targetColor.r, progress);
                float finalG = Mathf.Lerp(startColor.g, targetColor.g, progress);
                float finalB = Mathf.Lerp(startColor.b, targetColor.b, progress);
                float finalA = Mathf.Lerp(startColor.a, targetColor.a, progress);

                image.color = new Color(finalR, finalG, finalB, finalA);
            }            
        }
    }
}