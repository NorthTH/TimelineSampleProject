using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Timeline;

namespace DamriCustomTrack
{
    [TrackColor (0.2f, 0.394118f, 0.7117646f)]
    [TrackClipType (typeof(ImagePlayableAsset))]
    [TrackBindingType(typeof(Image))]
    public class ImageTrack : TrackAsset
    {
    }
}