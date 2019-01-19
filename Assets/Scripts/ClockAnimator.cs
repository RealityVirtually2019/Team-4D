using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class ClockAnimator : MonoBehaviour
{
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
        currentFrame = (int)System.Math.Ceiling(timeElapsed / timePerFrame);
        if (currentFrame < frames.Length && timeElapsed != 0f)
        {
            GetComponent<SpriteRenderer>().sprite = frames[currentFrame];
        }
        else
        {
            ResetAnimation();
        }
    }
}
