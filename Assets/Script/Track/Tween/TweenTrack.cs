using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Tween
{
    [TrackColor(0.855f,0.8623f,0.870f)]
    [TrackClipType(typeof(TweenClip))]
    [TrackBindingType(typeof(Transform))]
    public class TweenTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            var director = go.GetComponent<PlayableDirector>();
            var transform = director.GetGenericBinding(this) as Transform;

            var playable = ScriptPlayable<TweenMixerBehaviour>.Create(graph, inputCount);
            playable.GetBehaviour().transform = transform;

            return playable;
        }
    }
}