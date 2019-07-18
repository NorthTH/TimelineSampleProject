using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

[System.Serializable]
public class ImageColorAsset : PlayableAsset
{
    public ExposedReference<Image> image;
    public Image imagePrefab;
    public Color color;

    // Factory method that generates a playable based on this asset

    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        var playable = ScriptPlayable<ImageColorBehaviour>.Create(graph);

        // var director = go.GetComponent<PlayableDirector>();
        
        var imageColorBehaviour = playable.GetBehaviour();

        // imageColorBehaviour.image = director.GetGenericBinding(this) as Image;
        imageColorBehaviour.image = image.Resolve(graph.GetResolver());

        imageColorBehaviour.imagePrefab = imagePrefab;
        imageColorBehaviour.color = color;
        
        return playable;
    }
}
