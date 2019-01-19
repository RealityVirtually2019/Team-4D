using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ClockAnimator : MonoBehaviour
{
    public event Action<AnimationStartedArgs> AnimationStarted;
    public event Action<AnimationEndedArgs> AnimationEnded;


    [SerializeField]
    protected float duration = 0f;

    [SerializeField]
    protected Sprite[] frames = null;

    private bool isAnimating;
    private int currentFrame;
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        ResetAnimation();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetElapsedTime(float time)
    {
        if (timeElapsed == 0f)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.8f);
        } else
        {
            isAnimating = true;
            AnimationStarted(new AnimationStartedArgs(duration, frames.Length));
        }
        timeElapsed = time;
        CheckFrame();
    }

    private void ResetAnimation()
    {
        isAnimating = false;
        currentFrame = 0;
        timeElapsed = 0f;
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }

    private void CheckFrame()
    {
        float timePerFrame = duration / frames.Length;
        int oldFrame = currentFrame;
        currentFrame = (int)System.Math.Ceiling(timeElapsed / timePerFrame);
        if (currentFrame < frames.Length && timeElapsed != 0f)
        {
            GetComponent<SpriteRenderer>().sprite = frames[currentFrame];
        }
        else
        {
            if (currentFrame == frames.Length && currentFrame - 1 == oldFrame)
            {
                AnimationEnded(new AnimationEndedArgs(true, frames.Length - 1));
            } else if (timeElapsed == 0f)
            {
                AnimationEnded(new AnimationEndedArgs(false, oldFrame));
            }
            ResetAnimation();
        }
    }
}

public struct AnimationStartedArgs
{
    public AnimationStartedArgs(float duration, int spriteCount)
    {
        Duration = duration;
        SpriteCount = spriteCount;
    }

    public float Duration { get; }
    public int SpriteCount { get; }
}

public struct AnimationEndedArgs
{
    public AnimationEndedArgs(bool finished, int lastFrame)
    {
        Finished = finished;
        LastFrame = lastFrame;
    }

    public bool Finished { get; }
    public int LastFrame { get; }
}