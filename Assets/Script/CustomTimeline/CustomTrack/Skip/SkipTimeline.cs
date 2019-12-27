using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DamriCustomTrack
{
	public class SkipTimeline : MonoBehaviour
	{
		public bool _trigger;
		public UnityEvent[] SkipCheck;

		public bool trigger {
			get {
				#if UNITY_EDITOR
				if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode == false)
					return false;
				#endif
				return _trigger;
			}
			set {
				_trigger = value;
			}
		}

		public void callEvent(int index)
        {
            if(index >= SkipCheck.Length || index < 0 ) return;
            SkipCheck[index].Invoke();
        }
	}
}
