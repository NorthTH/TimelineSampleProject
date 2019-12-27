using UnityEngine;
using UnityEngine.Timeline;
using TMPro;

namespace DamriCustomTrack
{
    [TrackColor (0.1f, 0.294118f, 0.7117646f)]
    [TrackClipType (typeof(TextMeshProUGUIPlayableAsset))]
    [TrackBindingType(typeof(TextMeshProUGUI))]
    public class TextMeshProUGUITrack : TrackAsset
    {
    }
}