using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeManager : MonoBehaviour
{
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        this.cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(this.cam.transform.position, this.cam.transform.forward, out RaycastHit hitInfo, 20.0f, Physics.DefaultRaycastLayers))
        {
            Debug.Log(hitInfo);
        }
    }
}
