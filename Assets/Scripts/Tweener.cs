﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    private Tween activeTween;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }
 void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if(activeTween == null)
        activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(activeTween.Target.position, activeTween.EndPos) > 0.1f)
        {
            float t = (Time.time - activeTween.StartTime) / activeTween.Duration;
            Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, t);
        }
        
        if(Vector3.Distance(activeTween.Target.position, activeTween.EndPos) <= 0.1f)
        {
            activeTween.Target.position = activeTween.EndPos;
            activeTween == null;
        }

    }
}
