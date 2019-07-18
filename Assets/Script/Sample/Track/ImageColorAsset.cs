using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TestTrack
{
    [System.Serializable]
    public class ImageColorAsset : PlayableAsset
    {
        public ImageColorBehaviour data = new ImageColorBehaviour();
        
        // Factory method that generates a playable based on this asset
        public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
        {
            var playable = ScriptPlayable<ImageColorBehaviour>.Create (graph, data);
            ImageColorBehaviour clone = playable.GetBehaviour ();
            return playable;
        }
    }
}
