using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using TMPro;

namespace DamriCustomTrack
{
    [System.Serializable]
    public class TextMeshProUGUIPlayableAsset : PlayableAsset
    {
		public bool cutBlendRGB;
        public Color startTextColor = Color.white;
        public Color targetTextColor = Color.white;
		public AnimationCurve animationCurve = AnimationCurve.Linear(0, 0, 1, 1);

        public ClipCaps clipCaps {
			get { return ClipCaps.None; }
		}

		public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
		{
			var playable = ScriptPlayable<TextMeshProUGUIPlayableBehaviour>.Create (graph);
			var beheviour = playable.GetBehaviour ();
			
			beheviour.cutBlendRGB = cutBlendRGB;
			beheviour.startTextColor = startTextColor;
            beheviour.targetTextColor = targetTextColor;
			beheviour.animationCurve = animationCurve;
			return playable;
		}
    }
}