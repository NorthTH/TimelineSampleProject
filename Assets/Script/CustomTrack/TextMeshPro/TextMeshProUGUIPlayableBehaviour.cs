using UnityEngine;
using UnityEngine.Playables;
using TMPro;

namespace DamriCustomTrack
{
    [System.Serializable]
    public class TextMeshProUGUIPlayableBehaviour : PlayableBehaviour
    {
        public bool cutBlendRGB {set;get;}
        public Color startTextColor {set;get;}
        public Color targetTextColor {set;get;}
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
            TextMeshProUGUI textMesh = playerData as TextMeshProUGUI;
 
            if (textMesh != null)
            {
                float duration = (float)playable.GetDuration();
                float time = (float)playable.GetTime();

                float inverseDuration = 1f / duration;
                float normalisedTime = time * inverseDuration;
                float progress = animationCurve.Evaluate(normalisedTime);

                float finalR = (cutBlendRGB) ? textMesh.color.r : Mathf.Lerp(startTextColor.r, targetTextColor.r, progress);
                float finalG = (cutBlendRGB) ? textMesh.color.g : Mathf.Lerp(startTextColor.g, targetTextColor.g, progress);
                float finalB = (cutBlendRGB) ? textMesh.color.b : Mathf.Lerp(startTextColor.b, targetTextColor.b, progress);
                float finalA = Mathf.Lerp(startTextColor.a, targetTextColor.a, progress);

                textMesh.color = new Color(finalR, finalG, finalB, finalA);
            }            
        }
    }
}