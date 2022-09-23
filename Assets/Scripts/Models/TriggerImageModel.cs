using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerImageModel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DirArrow"))
        {
            DirectionModel dir = collision.GetComponent<DirectionModel>();
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
}