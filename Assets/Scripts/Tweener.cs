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
    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if(activeTween == null)
        activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
    }

    // Update is called once per frame
    void Update()
    {
        if(activeTween != null)
        
        {
            float distance = Vector3.Distance(activeTween.Target.position, activeTween.EndPos);
            
            if(distance > 0.1f)
            {
                float t = (Time.time - activeTween.StartTime) / activeTween.Duration;
                activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, t);
            }
        
            if(distance <= 0.1f)
            {
                activeTween.Target.position = activeTween.EndPos;
                activeTween = null;
            } 
        }
        

    }
}
