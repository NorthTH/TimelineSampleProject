using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;

namespace DamriCustomTrack
{
    [TrackColor (0.2f, 0.394118f, 0.3117646f)]
    [TrackClipType (typeof(RectTransformPlayableAsset))]
    [TrackBindingType(typeof(RectTransform))]
    public class RectTransformTrack : TrackAsset
    {
    }
}