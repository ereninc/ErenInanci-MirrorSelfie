using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoController :  ControllerModel
{
    [SerializeField] PoolModel photoPool;
    [SerializeField] ScreenModel endScreen;

    public void ShowPhoto(int index) 
    {
        PhotoModel photo = photoPool.GetDeactiveItem<PhotoModel>();
        photo.Show(index);
    }

    public void OnEnd() 
    {
        transform.SetParent(endScreen.transform);
    }
}