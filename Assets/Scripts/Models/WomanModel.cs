using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanModel : ObjectModel
{
    [SerializeField] Animator animator;
    private int lastIndex;

    public override void Initialize()
    {
        base.Initialize();
    }

    public void SetAnimation()
    {
        int index = getRandom(0, 4);
        animator.SetTrigger("Pose_" + index.ToString());
    }

    private int getRandom(int min, int max)
    {
        int rand = Random.Range(min, max);
        while (rand == lastIndex)
            rand = Random.Range(min, max);
        lastIndex = rand;
        return rand;
    }
}