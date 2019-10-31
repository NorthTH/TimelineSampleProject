using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace DamriCustomTrack
{
    [System.Serializable]
    public class CanvasGroupPlayableAsset : PlayableAsset
    {
        public float startAlpha;
        public float targetAlpha;
		public AnimationCurve animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

        public ClipCaps clipCaps {
			get { return ClipCaps.None; }
		}

		public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
		{
			var playable = ScriptPlayable<CanvasGroupPlayableBehaviour>.Create (graph);
			var beheviour = playable.GetBehaviour ();
			beheviour.startAlpha = startAlpha;
            beheviour.targetAlpha = targetAlpha;
			beheviour.animationCurve = animationCurve;
			return playable;
		}
    }
}