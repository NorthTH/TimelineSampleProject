using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace DamriCustomTrack
{
    [TrackColor (0.6f, 0.2794118f, 0.7117646f)]
    [TrackClipType (typeof(MaterialPropertyPlayableAsset))]
    [TrackBindingType (typeof(Material))]
    public class MaterialPropertyTrack : TrackAsset
    {
    }
}
