using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TriggerImageModel : MonoBehaviour
{
    [SerializeField] DirectionArrowController directionArrowController;
    [SerializeField] PhotoController photoController;
    [SerializeField] WomanModel womanModel;
    [SerializeField] FlashController flashController;
    [SerializeField] Image triggerImage;

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
            changeColor(true);
        }
        else
        {
            CurrentDirectionArrow.OnFailSwipe();
            changeColor(false);
        }
        directionArrowController.DecreaseArrowCount();
    }

    private void changeColor(bool correct) 
    {
        if (correct)
        {
            triggerImage.DOColor(Color.green, 0.25f).OnComplete(() => { triggerImage.DOColor(Color.white, 0.25f); });
        }
        else
        {
            triggerImage.DOColor(Color.red, 0.25f).OnComplete(() => { triggerImage.DOColor(Color.white, 0.25f); });
        }
    }
}