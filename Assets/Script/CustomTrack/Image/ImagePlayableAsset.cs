using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace DamriCustomTrack
{
    [System.Serializable]
    public class ImagePlayableAsset : PlayableAsset
    {
        public Color startColor = Color.white;
        public Color targetColor = Color.white;
		public AnimationCurve animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

        public ClipCaps clipCaps {
			get { return ClipCaps.None; }
		}

		public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
		{
			var playable = ScriptPlayable<ImagePlayableBehaviour>.Create (graph);
			var beheviour = playable.GetBehaviour ();
			beheviour.startColor = startColor;
            beheviour.targetColor = targetColor;
			beheviour.animationCurve = animationCurve;
			return playable;
		}
    }
}