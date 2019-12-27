using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UniRx.Async;

namespace DamriTimelineLibrary
{
    public static class PlayableDirectorExtensions
    {
        public static UniTask PlayAsync(this PlayableDirector self)
        {
            self.Play();
            return UniTask.WaitWhile(() => self.state == PlayState.Playing);
        }

        public static void SetBindingInTrack(this PlayableDirector self, Object obj, string TrackName)
        {
            var binding = self.playableAsset.outputs.First( c => c.streamName == TrackName);
            self.SetGenericBinding(binding.sourceObject, obj);
        }

        public static T GetClip<T>(this PlayableDirector self ,string trackName, string clipName) where T : PlayableAsset
        {
            // タイムライン内のトラック一覧を取得
            IEnumerable<TrackAsset> tracks = (self.playableAsset as TimelineAsset).GetOutputTracks();
            // 指定名称のトラックを抜き出す
            TrackAsset track = tracks.FirstOrDefault(x => x.name == trackName);

            if (track != null)
            {
                // トラック内のクリップ一覧を取得
                IEnumerable<TimelineClip> clips = track.GetClips();
                // 指定名称のクリップを抜き出す
                TimelineClip clip = clips.FirstOrDefault(x => x.displayName == clipName);

                if (clip != null && clip.asset != null)
                {
                    return clip.asset as T;
                }
            }

            return null;
        }
    }

    public static class TimelineExtensions
    {
        public static T GetClip<T>(this PlayableAsset self, string trackName, string clipName) where T : PlayableAsset
        {
            // タイムライン内のトラック一覧を取得
            IEnumerable<TrackAsset> tracks = (self as TimelineAsset).GetOutputTracks();
            // 指定名称のトラックを抜き出す
            TrackAsset track = tracks.FirstOrDefault(x => x.name == trackName);

            if (track != null)
            {
                // トラック内のクリップ一覧を取得
                IEnumerable<TimelineClip> clips = track.GetClips();
                // 指定名称のクリップを抜き出す
                TimelineClip clip = clips.FirstOrDefault(x => x.displayName == clipName);

                if (clip != null && clip.asset != null)
                {
                    return clip.asset as T;
                }
            }

            return null;
        }
    }
}