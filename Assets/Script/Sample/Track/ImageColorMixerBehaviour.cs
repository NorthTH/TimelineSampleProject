using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

namespace TestTrack
{
    // A behaviour that is attached to a playable
    public class ImageColorMixerBehaviour : PlayableBehaviour
    {
        public Image image {set;get;}

        Color originalColor;
        // Called when the owning graph starts playing
        public override void OnGraphStart(Playable playable)
        {
            if(image != null)
                originalColor = image.color;
        }

        // Called when the owning graph stops playing
        public override void OnGraphStop(Playable playable)
        {
            if(image != null)
                image.color = originalColor;
        }

        // Called when the state of the playable is set to Play
        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            
        }

        // Called when the state of the playable is set to Paused
        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            
        }

        // Called each frame while the state is set to Play
        public override void PrepareFrame(Playable playable, FrameData info)
        {
            if(image == null)
                return;
                
            int inputCount = playable.GetInputCount ();

            Color blendColor = Vector4.zero;

            for (int i = 0; i < inputCount; i++)
            {
                var playableInput = (ScriptPlayable<ImageColorBehaviour>)playable.GetInput (i);
                ImageColorBehaviour input = playableInput.GetBehaviour ();

                float inputWeight = playable.GetInputWeight(i);

                blendColor += input.color * inputWeight;
            }

            image.color = blendColor;
        }
    }
}