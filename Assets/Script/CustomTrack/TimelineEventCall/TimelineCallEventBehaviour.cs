using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace DamriCustomTrack
{
    public class TimelineCallEventBehaviour : PlayableBehaviour
    {
        public PlayableDirector director{get;set;}
        public TimelineCallEvent timelineEvent{get;set;}
        public int eventIndex;

        // Called when the state of the playable is set to Play
        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            if(timelineEvent == null) return;

            timelineEvent.callEvent(eventIndex);
        }

        // Called when the state of the playable is set to Paused
        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            
        }
    }
}
