using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace DamriCustomTrack
{
    [System.Serializable]
    public class TimelineCallEventAsset : PlayableAsset
    {
        public int eventIndex;
        public ClipCaps clipCaps { get { return ClipCaps.None; } }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
        {
            var Playable = ScriptPlayable<TimelineCallEventBehaviour>.Create(graph);
            var beheviour = Playable.GetBehaviour();
            beheviour.director = go.GetComponent<PlayableDirector>();
            beheviour.timelineEvent = go.GetComponent<TimelineCallEvent>();
            beheviour.eventIndex = eventIndex;
            return Playable;
        }
    }
}
