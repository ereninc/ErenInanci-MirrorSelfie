using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DirectionModel : ObjectModel
{
    public SwipeDirections Direction;
    [SerializeField] Transform targetPos;
    [SerializeField] Animator animator;
    [SerializeField] Image arrowImage;

    public void OnSpawn(Transform targetParent)
    {
        SetActivate();
        setDefaultValues();
        transform.position = targetParent.position;
        transform.DOMoveX(targetPos.position.x, 5f).SetEase(Ease.Linear).OnComplete(() =>
        {
            setDefaultValues();
            SetDeactive();
            DOTween.Kill(transform);
        });
    }

    public void OnCorrectSwipe()
    {
        animator.Play("OnCorrect");
    }

    public void OnFailSwipe()
    {
        animator.Play("OnFail");
    }

    public void SetDirection(SwipeDirections dir)
    {
        switch (dir)
        {
            case SwipeDirections.Left:
                Direction = SwipeDirections.Left;
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case SwipeDirections.Up:
                Direction = SwipeDirections.Up;
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case SwipeDirections.Right:
                Direction = SwipeDirections.Right;
                transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case SwipeDirections.Down:
                Direction = SwipeDirections.Down;
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case SwipeDirections.None:
                Direction = SwipeDirections.None;
                break;
            default:
                break;
        }
    }

    public void OnAnswered()
    {
        setDefaultValues();
        SetDeactive();
        DOTween.Kill(transform);
    }

    private void setDefaultValues()
    {
        animator.Play("Idle");
        arrowImage.color = new Color(1, 1, 1, 1);
        transform.localPosition = new Vector3(transform.localPosition.x, 0, transform.localPosition.z);
    }
}