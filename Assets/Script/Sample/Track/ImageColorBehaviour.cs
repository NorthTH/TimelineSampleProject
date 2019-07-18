using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace TestTrack{
    // A behaviour that is attached to a playable
    [System.Serializable]
    public class ImageColorBehaviour : PlayableBehaviour
    {
        public Color color;
    }
}