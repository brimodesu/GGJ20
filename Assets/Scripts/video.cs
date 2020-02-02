using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Video;

public class video : MonoBehaviour
{
    [CanBeNull] public Camera camer_;

    public VideoPlayer videop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        camer_ = Camera.main;
        videop = this.GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
