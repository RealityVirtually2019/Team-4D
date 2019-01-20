using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(GazeManager))]
public class GazeAttacher : MonoBehaviour
{
    private GazeManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<GazeManager>();
        manager.OnSelectedOutline += OnSelectedOutline;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        manager.OnSelectedOutline -= OnSelectedOutline;
        manager.shouldObserveOutlines = true;
    }

    private void OnSelectedOutline(SelectedOutlineArgs args)
    {
        args.OutlineObject.transform.parent.parent = gameObject.transform;
        manager.shouldObserveOutlines = false;
    }
}
