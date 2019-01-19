using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class GazeManager : MonoBehaviour
{
    [SerializeField]
    protected SpriteRenderer clock;

    private Camera cam;
    private GlowObject currentObject;
    private float timeLookingAtCurrentObject;

    private ClockAnimator animator;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        timeLookingAtCurrentObject = 0f;
        animator = clock.GetComponent<ClockAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectGlowObjects();

        int speed = 5;
        if (Input.GetKey(KeyCode.UpArrow)) transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.DownArrow)) transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.LeftArrow)) transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.RightArrow)) transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);

    }

    private void DetectGlowObjects()
    {
        bool detectedGlowObject = false;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, 20.0f, Physics.DefaultRaycastLayers))
        {
            GlowObject glowObject = hitInfo.transform.gameObject.GetComponent<GlowObject>();
            if (glowObject != null)
            {
                glowObject.OnRaycastHit();
                currentObject = glowObject;
                timeLookingAtCurrentObject += Time.deltaTime;
                animator.SetElapsedTime(timeLookingAtCurrentObject);
                detectedGlowObject = true;
            }
        }
        if (!detectedGlowObject && currentObject != null)
        {
            currentObject.OnRaycastEnd();
            timeLookingAtCurrentObject = 0f;
            currentObject = null;
            animator.SetElapsedTime(timeLookingAtCurrentObject);
        }
    }
}
