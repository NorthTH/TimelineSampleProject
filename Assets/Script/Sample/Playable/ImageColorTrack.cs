using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.Timeline;


[TrackClipType(typeof(ImageColorAsset))]
[TrackBindingType(typeof(Image))]
public class ImageColorTrack : TrackAsset {}