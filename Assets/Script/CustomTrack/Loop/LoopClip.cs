using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace DamriCustomTrack
{
	[Serializable]
	public class LoopClip : PlayableAsset, ITimelineClipAsset
	{
		public int eventIndex;
		public ClipCaps clipCaps {
			get { return ClipCaps.None; }
		}

		public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
		{
			var playable = ScriptPlayable<LoopBehaviour>.Create (graph);
			LoopBehaviour beheviour = playable.GetBehaviour ();
			beheviour.director = owner.GetComponent<PlayableDirector> ();
			beheviour.loopTimeline = owner.GetComponent<LoopTimeline> ();
			beheviour.eventIndex = eventIndex;
			return playable;
		}
	}
}
