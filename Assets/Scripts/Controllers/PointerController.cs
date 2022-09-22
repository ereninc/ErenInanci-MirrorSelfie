using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PointerController : ControllerModel
{
    public float SwipeThreshold = 50f;
    public UnityEvent OnSwipeLeft;
    public UnityEvent OnSwipeRight;
    public UnityEvent OnSwipeUp;
    public UnityEvent OnSwipeDown;

    private Vector2 onPointerDownPos;
    private Vector2 onPointerUpPos;

    public override void ControllerUpdate()
    {
        base.ControllerUpdate();
        if (GameStateController.CurrentState == GameStates.Game)
        {
            pointerUpdate();
        }
    }

    private void pointerUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onPointerDownPos = Input.mousePosition;
            onPointerUpPos = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            onPointerDownPos = Input.mousePosition;
            CheckSwipe();
        }
    }

    private void CheckSwipe()
    {
        float deltaX = onPointerDownPos.x - onPointerUpPos.x;
        if (Mathf.Abs(deltaX) > SwipeThreshold)
        {
            if (deltaX > 0)
            {
                OnSwipeRight.Invoke();
                Debug.Log("right");
            }
            else if (deltaX < 0)
            {
                OnSwipeLeft.Invoke();
                Debug.Log("left");
            }
        }

        float deltaY = onPointerDownPos.y - onPointerUpPos.y;
        if (Mathf.Abs(deltaY) > SwipeThreshold)
        {
            if (deltaY > 0)
            {
                OnSwipeUp.Invoke();
                Debug.Log("up");
            }
            else if (deltaY < 0)
            {
                OnSwipeDown.Invoke();
                Debug.Log("down");
            }
        }
        onPointerUpPos = onPointerDownPos;
    }
}