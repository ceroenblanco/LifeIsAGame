using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UI_AnimationTypes
{
    Move, Scale, ScaleX, ScaleY, Fade
}

public class UI_Tween : MonoBehaviour
{
    public GameObject objectToAnimate;

    public UI_AnimationTypes animaionType;
    public LeanTweenType easeType;
    public float duration;
    public float delay;

    public bool loop;
    public bool pingpong;

    public bool startPositionOffset;
    public Vector3 from = Vector3.one;
    public Vector3 to = Vector3.one;

    private LTDescr _tweenObject;

    public bool showOnEnable;
    public bool workOnDisable;

    public void OnEnable()
    {
        if (showOnEnable)
        {
            Show();
        }
    }

    public void Show ()
    {
        HandleTween();
    }

    public void HandleTween ()
    {
        if (objectToAnimate == null)
        {
            objectToAnimate = gameObject;
        }

        switch (animaionType)
        {
            case UI_AnimationTypes.Move:
                MoveAbsolute();
                break;

            case UI_AnimationTypes.Scale:
                Scale();
                break;

            case UI_AnimationTypes.ScaleX:
                Scale();
                break;

            case UI_AnimationTypes.ScaleY:
                Scale();
                break;

            case UI_AnimationTypes.Fade:
                Fade();
                break;

            default:
                break;
        }

        _tweenObject.setDelay(delay);
        _tweenObject.setEase(easeType);

        if (loop)
        {
            _tweenObject.loopCount = int.MaxValue;
        }

        if (pingpong)
        {
            _tweenObject.setLoopPingPong();
        }
    }

    public void Fade ()
    {
        if (gameObject.GetComponent<CanvasGroup>() == null)
        {
            gameObject.AddComponent<CanvasGroup>();
        }

        if (startPositionOffset)
        {
            objectToAnimate.GetComponent<CanvasGroup>().alpha = from.x;
        }

        _tweenObject = LeanTween.alphaCanvas(objectToAnimate.GetComponent<CanvasGroup>(), to.x, duration);
    }

    public void MoveAbsolute ()
    {
        objectToAnimate.GetComponent<RectTransform>().anchoredPosition = from;

        _tweenObject = LeanTween.move(objectToAnimate.GetComponent<RectTransform>(), to, duration);
    }

    public void Scale ()
    {
        if (startPositionOffset)
        {
            objectToAnimate.GetComponent<RectTransform>().localScale = from;
        }

        _tweenObject = LeanTween.scale(objectToAnimate, to, duration);
    }
}
