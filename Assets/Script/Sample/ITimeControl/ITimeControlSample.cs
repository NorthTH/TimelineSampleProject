using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class ITimeControlSample : MonoBehaviour, ITimeControl
{   
    public float speed;

    Vector3 startPos;

    public void OnControlTimeStart()
    {
        startPos = transform.position;
    }
       
    public void OnControlTimeStop()
    {
        transform.position = startPos;
    }

    public void SetTime(double time)
    {
        transform.position = new Vector3( startPos.x + (float)time * speed , startPos.y, startPos.z);
    }
}
