using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventModel : MonoBehaviour
{
    [System.Serializable]
    public class TrigEvent : UnityEvent { }
    public TrigEvent OnTrig;
    [SerializeField] Transform t;
    [SerializeField] Transform mainScreen;

    public void Trigger()
    {
        OnTrig.Invoke();
    }

    public void SetActive()
    {
        t.gameObject.SetActive(true);
    }

    public void SetGameState() 
    {
        GameStateController.Instance.ChangeState(GameStates.Game);
        ScreenController.Instance.ShowScreen(1);
    }

    public void SetDeactive()
    {
        mainScreen.gameObject.SetActive(false);
    }
}