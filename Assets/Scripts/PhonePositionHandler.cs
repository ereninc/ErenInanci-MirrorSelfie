using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhonePositionHandler : ControllerModel
{
    [SerializeField] Transform phoneParent;
    [SerializeField] Vector3[] posePositions;

    public void SetPosition(int index) 
    { 
        phoneParent.localPosition = posePositions[index];
    }
}