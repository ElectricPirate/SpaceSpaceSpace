using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float Speed;
    private Vector3 StartPosition;
    
    void Start()
    {
        StartPosition = transform.position;
    }

    
    void Update()
    {
        var newZPosition = Mathf.Repeat(Time.time * Speed, 100f);
        transform.position = StartPosition + Vector3.back * newZPosition;
    }
}
