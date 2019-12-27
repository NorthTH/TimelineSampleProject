using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DamriCustomTrack
{
    public class TimelineCallEvent : MonoBehaviour
    {
        public UnityEvent[] events;

        public void callEvent(int index)
        {
            if(index >= events.Length) return;
            events[index].Invoke();
        }
    }
}
