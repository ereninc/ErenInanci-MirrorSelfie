using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WomanModel : ObjectModel
{
    [SerializeField] Animator animator;
    [SerializeField] PhonePositionHandler phonePositionHandler;
    private int animationIndex;
    private int lastIndex;

    public void SetAnimation()
    {
        animationIndex = getRandom(0, 4);
        animator.SetTrigger("Pose_" + animationIndex.ToString());
        phonePositionHandler.SetPosition(animationIndex);
    }

    public int GetAnimationIndex()
    {
        return animationIndex;
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