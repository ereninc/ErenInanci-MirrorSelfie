using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanModel : ObjectModel
{
    [SerializeField] Animator animator;

    public override void Initialize()
    {
        base.Initialize();
    }

    public void SetAnimation()
    {
        int index = Random.Range(0, 4);
        animator.SetTrigger("Pose_" + index.ToString());
    }
}