using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace DamriCustomTrack
{
    [System.Serializable]
    public class RectTransformPlayableAsset : PlayableAsset
    {
        public Vector2 startSize;
        public Vector2 targetSize;
		public AnimationCurve animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

        public ClipCaps clipCaps {
			get { return ClipCaps.None; }
		}

        public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
		{
			var playable = ScriptPlayable<RectTransformPlayableBehaviour>.Create (graph);
			var beheviour = playable.GetBehaviour ();
			beheviour.startSize = startSize;
            beheviour.targetSize = targetSize;
			beheviour.animationCurve = animationCurve;
			return playable;
		}
    }
}
