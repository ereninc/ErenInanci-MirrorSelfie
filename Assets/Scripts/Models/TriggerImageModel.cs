using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerImageModel : MonoBehaviour
{
    [SerializeField] DirectionArrowController directionArrowController;
    [SerializeField] PhotoController photoController;
    [SerializeField] WomanModel womanModel;
    [SerializeField] FlashController flashController;

    public DirectionModel CurrentDirectionArrow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DirArrow"))
        {
            CurrentDirectionArrow = collision.GetComponent<DirectionModel>();
            PointerController.Instance.IsQuickTime = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("DirArrow"))
        {
            PointerController.Instance.IsQuickTime = false;
        }
    }

    public void CheckDirection(SwipeDirections dir) 
    {
        if (CurrentDirectionArrow.Direction == dir)
        {
            CurrentDirectionArrow.OnCorrectSwipe();
            photoController.ShowPhoto(womanModel.GetAnimationIndex());
            flashController.Flash();
        }
        else
        {
            CurrentDirectionArrow.OnFailSwipe();
        }
        directionArrowController.DecreaseArrowCount();
    }
}