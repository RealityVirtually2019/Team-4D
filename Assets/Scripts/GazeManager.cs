using cakeslice;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

[RequireComponent(typeof(Camera))]
public class GazeManager : MonoBehaviour
{
    [SerializeField]
    protected SpriteRenderer clock;

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

        int speed = 5;
        if (Input.GetKey(KeyCode.UpArrow)) transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed * 10);
        if (Input.GetKey(KeyCode.DownArrow)) transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed * 10);
        if (Input.GetKey(KeyCode.LeftArrow)) transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);
        if (Input.GetKey(KeyCode.RightArrow)) transform.Translate(new Vector3(1, 0, 0) * Time.deltaTime * speed);

    }

    private void DetectGlowObjects()
    {
        bool detectedGlowObject = false;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, 20.0f, Physics.DefaultRaycastLayers))
        {
            Outline glowObject = hitInfo.transform.gameObject.GetComponent<Outline>();
            if (glowObject != null)
            {
                glowObject.eraseRenderer = false;
                currentObject = glowObject;
                timeLookingAtCurrentObject += Time.deltaTime;
                animator.SetElapsedTime(timeLookingAtCurrentObject);
                detectedGlowObject = true;
            }
        }
        if (!detectedGlowObject && currentObject != null)
        {
            currentObject.eraseRenderer = true;
            timeLookingAtCurrentObject = 0f;
            currentObject = null;
            animator.SetElapsedTime(timeLookingAtCurrentObject);
        }
    }

    private void OnDestroy()
    {
        recognizer.Tapped -= OnGestureTapped;
        recognizer.HoldStarted -= OnGestureHoldStart;
        recognizer.HoldCompleted -= OnGestureHoldComplete;
        recognizer.HoldCanceled -= OnGestureHoldCanceled;
        recognizer.StopCapturingGestures();
    }

    private void OnAnimationEnded(AnimationEndedArgs args)
    {
        if (args.Finished && currentObject != null)
        {
            currentObject.transform.parent = gameObject.transform;
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
