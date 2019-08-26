using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Tween
{
    [Serializable]
    public class TweenClip : PlayableAsset, ITimelineClipAsset
    {
        public TweenBehaviour tween = new TweenBehaviour ();
        
        public ClipCaps clipCaps
        {
            get { return ClipCaps.Blending; }
        }

        public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<TweenBehaviour>.Create (graph, tween);
            TweenBehaviour clone = playable.GetBehaviour ();
            return playable;
        }
    }
}