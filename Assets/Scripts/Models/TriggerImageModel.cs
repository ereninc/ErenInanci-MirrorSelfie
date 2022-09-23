using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerImageModel : MonoBehaviour
{
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
        }
        else
        {
            CurrentDirectionArrow.OnFailSwipe();
        }
    }
}