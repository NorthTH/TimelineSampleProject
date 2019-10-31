using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace DamriCustomTrack
{
    [TrackColor(0.855f,0.8623f,0.870f)]
    [TrackClipType(typeof(TweenClip))]
    [TrackBindingType(typeof(Transform))]
    public class TweenTrack : TrackAsset
    {
        public bool useStartRectTranform;
        public Vector3 startPosition;
        public Vector3 startRotation;
        public Vector3 startScale = Vector3.one;

        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            var director = go.GetComponent<PlayableDirector>();
            var transform = director.GetGenericBinding(this) as Transform;

            var playable = ScriptPlayable<TweenMixerBehaviour>.Create(graph, inputCount);
            if(useStartRectTranform)
            {
                playable.GetBehaviour().startPosition = startPosition;
                playable.GetBehaviour().startRotation = Quaternion.Euler(startRotation);
                playable.GetBehaviour().startScale = startScale;
            }
            
            playable.GetBehaviour().transform = transform;
            playable.GetBehaviour().useStartRectTranform = useStartRectTranform;

            return playable;
        }
    }
}