using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace DamriCustomTrack
{
	[Serializable]
	public class LoopBehaviour : PlayableBehaviour
	{
		public PlayableDirector director { get; set; }
		public LoopTimeline loopTimeline { get; set; }
		public int eventIndex;

		public override void OnBehaviourPause (Playable playable, FrameData info)
		{
			if (loopTimeline.trigger == true) {
				loopTimeline.trigger = false;
				return;
			}

			// Debug.Log (waitTimeline.trigger);
			loopTimeline.callEvent(eventIndex);
			director.time -= playable.GetDuration ();
		}
	}
}
