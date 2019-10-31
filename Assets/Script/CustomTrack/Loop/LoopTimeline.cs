using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DamriCustomTrack
{
	public class LoopTimeline : MonoBehaviour
	{
		public bool _trigger;
		public UnityEvent[] LoopEvents;

		public bool trigger {
			get {
				#if UNITY_EDITOR
				if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode == false)
					return true;
				#endif
				return _trigger;
			}
			set {
				_trigger = value;
			}
		}

        public void callEvent(int index)
        {
            if(index >= LoopEvents.Length || index < 0 ) return;
            LoopEvents[index].Invoke();
        }
	}
}
