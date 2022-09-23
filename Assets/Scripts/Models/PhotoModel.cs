using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PhotoModel : ObjectModel
{
    [SerializeField] Image pose;
    [SerializeField] Sprite[] poses;
    [SerializeField] Animator animator;

    public void Show(int index)
    {
        SetActivate();
        pose.sprite = poses[index];
    }

    public void OnEnd()
    {
        animator.enabled = false;
        transform.DOLocalMove(Random.insideUnitCircle * 500, 0.25f);
    }
}