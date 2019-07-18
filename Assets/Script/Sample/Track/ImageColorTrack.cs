using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TestTrack
{
    [TrackColor(0.855f,0.8623f,0.870f)]
    [TrackClipType(typeof(ImageColorAsset))]
    [TrackBindingType(typeof(Image))]
    public class ImageColorTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            var director = go.GetComponent<PlayableDirector>();
            var image = director.GetGenericBinding(this) as Image;

            var playable = ScriptPlayable<ImageColorMixerBehaviour>.Create(graph, inputCount);
            playable.GetBehaviour().image = image;

            return playable;
        }
    }
}
