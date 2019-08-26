using System;
using UnityEngine;
using UnityEngine.Playables;

namespace Tween
{
    public class TweenMixerBehaviour : PlayableBehaviour
    {
        public Transform transform { get; set; }

        Vector3 defaultPosition;
        Quaternion defaultRotation;
        Vector3 defaultScale;

        public override void OnGraphStart(Playable playable)
        {
            if(transform == null)
                return;
            defaultPosition = transform.localPosition;
            defaultRotation = transform.localRotation;
            defaultScale = transform.localScale;
        }

        public override void OnGraphStop(Playable playable)
        {
            if(transform == null)
                return;
            transform.localPosition = defaultPosition;
            transform.localRotation = defaultRotation;
            transform.localScale = defaultScale;
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            if(transform == null)
                return;
                
            int inputCount = playable.GetInputCount ();

            float scaleTotalWeight = 0f;

            Vector3 blendedPosition = Vector3.zero;
            Vector3 blendedRotation = Vector3.zero;
            Vector3 blendedScale = Vector3.zero;

            for (int i = 0; i < inputCount; i++)
            {
                var playableInput = (ScriptPlayable<TweenBehaviour>)playable.GetInput (i);
                TweenBehaviour input = playableInput.GetBehaviour ();

                float inputWeight = playable.GetInputWeight(i);

                double duration = playableInput.GetDuration();
                float inverseDuration = 1f / (float)duration;

                float normalisedTime = (float)(playableInput.GetTime() * inverseDuration);
                float tweenPosProgress = input.position.currentCurve.Evaluate(normalisedTime);
                float tweenRotateProgress = input.rotation.currentCurve.Evaluate(normalisedTime);
                float tweenScaleProgress = input.scale.currentCurve.Evaluate(normalisedTime);
 
                scaleTotalWeight += inputWeight;
                blendedPosition += Vector3.Lerp(input.position.startOffSet, input.position.endOffSet, tweenPosProgress) * inputWeight;

                blendedRotation += Vector3.Lerp(input.rotation.startOffSet, input.rotation.endOffSet, tweenRotateProgress) * inputWeight;
                
                blendedScale += Vector3.Lerp(input.scale.startOffSet, input.scale.endOffSet, tweenScaleProgress) * inputWeight;
            }

            transform.localPosition = defaultPosition + blendedPosition;

            transform.rotation = defaultRotation * Quaternion.Euler(blendedRotation);

            transform.localScale = defaultScale + blendedScale;
        }
    }
}