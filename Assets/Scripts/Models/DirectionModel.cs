using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DirectionModel : ObjectModel
{
    public SwipeDirections Direction;
    [SerializeField] Transform targetPos;

    public override void Initialize()
    {
        base.Initialize();
    }

    public void OnSpawn(Transform targetParent) 
    {
        SetActivate();
        transform.position = targetParent.position;
        transform.DOMoveX(targetPos.position.x, 5f).SetEase(Ease.Linear).OnComplete(() => 
        { 
            SetDeactive();
            DOTween.Kill(transform);
        });
    }

    public void OnCorrectSwipe() 
    {
        
    }

    public void OnFailSwipe() 
    {
        
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
}