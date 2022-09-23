using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashController : ControllerModel
{
    [SerializeField] Animator animator;

    public void Flash() 
    {
        animator.Play("FlashEffect");
    }
}
