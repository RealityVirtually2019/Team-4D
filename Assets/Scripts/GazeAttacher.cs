using UnityEngine;
using Academy.HoloToolkit.Unity;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(GazeManager))]
[RequireComponent(typeof(AudioSource))]
public class GazeAttacher : Singleton<GazeAttacher>
{
    [SerializeField]
    public AudioClip playOnAttach;

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

    public void DetachOutline()
    {
        manager.shouldObserveOutlines = true;
    }

    private void OnDestroy()
    {
        manager.OnSelectedOutline -= OnSelectedOutline;
        manager.shouldObserveOutlines = true;
    }

    private void OnSelectedOutline(SelectedOutlineArgs args)
    {
        Transform crateEmpty = args.OutlineObject.transform.parent;
        crateEmpty.parent = gameObject.transform;
        crateEmpty.GetComponent<BoxCollider>().isTrigger = true;
        Rigidbody rb = crateEmpty.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
        manager.shouldObserveOutlines = false;

        // Play game sound
        if (playOnAttach != null)
        {
            GetComponent<AudioSource>().PlayOneShot(playOnAttach);
        }
    }
}
