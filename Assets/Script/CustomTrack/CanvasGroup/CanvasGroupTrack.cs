using UnityEngine;
using UnityEngine.Timeline;

namespace DamriCustomTrack
{
    [TrackColor (0.9f, 0.594118f, 0.7117646f)]
    [TrackClipType (typeof(CanvasGroupPlayableAsset))]
    [TrackBindingType(typeof(CanvasGroup))]
    public class CanvasGroupTrack : TrackAsset
    {
    }
}