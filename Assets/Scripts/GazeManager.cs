using cakeslice;
using System;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

[RequireComponent(typeof(Camera))]
public class GazeManager : MonoBehaviour
{
    public event Action<SelectedOutlineArgs> OnSelectedOutline;

    [SerializeField]
    protected SpriteRenderer clock;

    [SerializeField]
    public bool shouldObserveOutlines = true;

    private Camera cam;
    private Outline currentObject;
    private float timeLookingAtCurrentObject;

    private ClockAnimator animator;
    private GestureRecognizer recognizer;

    private float startingYRotation;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        timeLookingAtCurrentObject = 0f;
        startingYRotation = gameObject.transform.rotation.y;

        animator = clock.GetComponent<ClockAnimator>();
        animator.AnimationEnded += OnAnimationEnded;

        recognizer = new GestureRecognizer();
        recognizer.SetRecognizableGestures(GestureSettings.Tap | GestureSettings.Hold);
        recognizer.Tapped += OnGestureTapped;
        recognizer.HoldStarted += OnGestureHoldStart;
        recognizer.HoldCompleted += OnGestureHoldComplete;
        recognizer.HoldCanceled += OnGestureHoldCanceled;
        recognizer.StartCapturingGestures();
    }

    // Update is called once per frame
    void Update()
    {
        DetectGlowObjects();
    }

    private void DetectGlowObjects()
    {
        if (!shouldObserveOutlines)
        {
            return;
        }
        Outline newGlowObject = null;
        bool detectedGlowObject = false;
        bool hit3D = Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, 20.0f, Physics.DefaultRaycastLayers);
        RaycastHit2D hitInfo2D = Physics2D.Raycast(cam.transform.position, cam.transform.forward, 20.0f);
        if (hit3D) {
            Outline glowObject = hitInfo.transform.gameObject.GetComponent<Outline>();
            if (glowObject == null && hitInfo.transform.childCount > 0)
            {
                glowObject = hitInfo.transform.GetChild(0).gameObject.GetComponent<Outline>();
            }
            if (glowObject != null)
            {
                newGlowObject = glowObject;
                detectedGlowObject = true;
            }
        }
        else if(hitInfo2D) {
            Outline glowObject = hitInfo2D.transform.gameObject.GetComponent<Outline>();
            if (glowObject != null)
            {
                newGlowObject = glowObject;
                detectedGlowObject = true;
            }
        }
        if(currentObject != newGlowObject) {
            if(currentObject != null) {
                currentObject.eraseRenderer = true;
            }
            timeLookingAtCurrentObject = 0f;
            currentObject = null;
            animator.SetElapsedTime(timeLookingAtCurrentObject);
        }

        if(detectedGlowObject) {
            newGlowObject.eraseRenderer = false;
            timeLookingAtCurrentObject += Time.deltaTime;
            animator.SetElapsedTime(timeLookingAtCurrentObject);
            currentObject = newGlowObject;
        }
    }

    private void OnDestroy()
    {
        animator.AnimationEnded -= OnAnimationEnded;
        if (recognizer != null)
        {
            recognizer.Tapped -= OnGestureTapped;
            recognizer.HoldStarted -= OnGestureHoldStart;
            recognizer.HoldCompleted -= OnGestureHoldComplete;
            recognizer.HoldCanceled -= OnGestureHoldCanceled;
            recognizer.StopCapturingGestures();

        }
    }

    private void OnAnimationEnded(AnimationEndedArgs args)
    {
        if (args.Finished && currentObject != null && OnSelectedOutline != null)
        {
            OnSelectedOutline(new SelectedOutlineArgs(currentObject));
        }
    }

    private void OnGestureTapped(TappedEventArgs args)
    {
        // throw new NotImplementedException();
    }

    private void OnGestureHoldStart(HoldStartedEventArgs args)
    {
        // throw new NotImplementedException();
    }

    private void OnGestureHoldComplete(HoldCompletedEventArgs args)
    {
        // throw new NotImplementedException();
    }

    private void OnGestureHoldCanceled(HoldCanceledEventArgs args)
    {
        // throw new NotImplementedException();
    }
}

public struct SelectedOutlineArgs
{
    public SelectedOutlineArgs(Outline outlineObject)
    {
        OutlineObject = outlineObject;
    }

    public Outline OutlineObject { get; }
}
