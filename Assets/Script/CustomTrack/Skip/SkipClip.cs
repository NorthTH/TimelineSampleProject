using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace DamriCustomTrack
{
	[Serializable]
	public class SkipClip : PlayableAsset, ITimelineClipAsset
	{
		public int eventIndex;
		public ClipCaps clipCaps {
			get { return ClipCaps.None; }
		}

		public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
		{
			var playable = ScriptPlayable<SkipBehaviour>.Create (graph);
			SkipBehaviour beheviour = playable.GetBehaviour ();
			beheviour.director = owner.GetComponent<PlayableDirector> ();
			beheviour.skipTimeline = owner.GetComponent<SkipTimeline> ();
			beheviour.eventIndex = eventIndex;
			return playable;
		}
	}
}
