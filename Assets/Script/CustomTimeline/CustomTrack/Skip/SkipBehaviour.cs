using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace DamriCustomTrack
{
	[Serializable]
	public class SkipBehaviour : PlayableBehaviour
	{
		public PlayableDirector director { get; set; }
		public SkipTimeline skipTimeline { get; set; }
		public int eventIndex;

		public override void OnBehaviourPlay (Playable playable, FrameData info)
		{
			skipTimeline.callEvent(eventIndex);
			
			if (skipTimeline.trigger == true) {
				// Debug.Log (skipTimeline.trigger);
				skipTimeline.trigger = false;
				director.time += playable.GetDuration ();
				return;
			}	
		}
	}
}
