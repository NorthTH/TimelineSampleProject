using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UniRx.Async;

namespace DamriCustomTrack
{
    public static class TimelineLibrary
    {
        public static void SetGenericBinding<T>(PlayableDirector director, T obj, string TrackName) where T : Object
        {
            var binding = director.playableAsset.outputs.First( c => c.streamName == TrackName);
            director.SetGenericBinding(binding.sourceObject, obj);
        }
    }

    public static class PlayableDirectorExtensions
    {
        public static UniTask PlayAsync(this PlayableDirector self)
        {
            self.Play();
            return UniTask.WaitWhile(() => self.state == PlayState.Playing);
        }
    }
}
