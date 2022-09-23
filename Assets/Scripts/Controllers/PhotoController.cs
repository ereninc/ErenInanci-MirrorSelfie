using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoController :  ControllerModel
{
    [SerializeField] PoolModel photoPool;
    [SerializeField] ScreenModel endScreen;
    [SerializeField] List<PhotoModel> photos;

    public void ShowPhoto(int index) 
    {
        PhotoModel photo = photoPool.GetDeactiveItem<PhotoModel>();
        photo.Show(index);
        photos.Add(photo);
    }

    public void OnEnd() 
    {
        transform.SetParent(endScreen.transform);
        for (int i = 0; i < photos.Count; i++)
        {
            photos[i].OnEnd();
        }
    }
}