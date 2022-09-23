using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoModel : ObjectModel
{
    [SerializeField] Image pose;
    [SerializeField] Sprite[] poses;

    public void Show(int index)
    {
        SetActivate();
        pose.sprite = poses[index];
    }
}