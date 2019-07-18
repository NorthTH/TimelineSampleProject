using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

// A behaviour that is attached to a playable
public class ImageColorBehaviour : PlayableBehaviour
{
    public Image image;
    public Image imagePrefab;
    public Color color;

    Color originColor;

    // Called when the owning graph starts playing
    public override void OnGraphStart(Playable playable)
    {
        originColor = image.color;
    }

    // Called when the owning graph stops playing
    public override void OnGraphStop(Playable playable)
    {
        image.color = originColor;
    }

    // Called when the state of the playable is set to Play
    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {

    }

    // Called when the state of the playable is set to Paused
    public override void OnBehaviourPause(Playable playable, FrameData info)
    {

    }

    // Called each frame while the state is set to Play
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        if(image == null) return;
            image.color = color;
    }
}
