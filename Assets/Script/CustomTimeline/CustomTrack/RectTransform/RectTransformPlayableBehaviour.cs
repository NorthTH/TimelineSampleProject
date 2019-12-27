using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class RectTransformPlayableBehaviour : PlayableBehaviour
{
    public Vector2 startSize {set;get;}
    public Vector2 targetSize {set;get;}
    public AnimationCurve animationCurve {set;get;}

    // Called each frame while the state is set to Play
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            RectTransform rect = playerData as RectTransform;
 
            if (rect != null)
            {
                float duration = (float)playable.GetDuration();
                float time = (float)playable.GetTime();

                float inverseDuration = 1f / duration;
                float normalisedTime = time * inverseDuration;
                float progress = animationCurve.Evaluate(normalisedTime);

                float x = Mathf.Lerp(startSize.x, targetSize.x, progress);
                float y = Mathf.Lerp(startSize.y, targetSize.y, progress);

                rect.sizeDelta = new Vector2(x, y);
            }            
        }
}
