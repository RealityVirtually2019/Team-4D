using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class GazeManager : MonoBehaviour
{
    private Camera cam;
    private GlowObject currentObject;

    // Start is called before the first frame update
    void Start()
    {
        this.cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.currentObject != null)
        {
            this.currentObject.OnRaycastEnd();
        }
        if (Physics.Raycast(this.cam.transform.position, this.cam.transform.forward, out RaycastHit hitInfo, 20.0f, Physics.DefaultRaycastLayers))
        {
            GlowObject glowObject = hitInfo.transform.gameObject.GetComponent<GlowObject>();
            if (glowObject != null)
            {
                glowObject.OnRaycastHit();
                this.currentObject = glowObject;
            }
        }

        int speed = 5;
        if (Input.GetKey(KeyCode.UpArrow)) transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.DownArrow)) transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.LeftArrow)) transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.RightArrow)) transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);

    }
}
