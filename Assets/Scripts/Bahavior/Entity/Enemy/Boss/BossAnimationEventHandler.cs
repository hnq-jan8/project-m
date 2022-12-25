using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BossAnimationEventHandler : MonoBehaviour
{
    public UnityEvent doOnEvent;

    public UnityEvent[] test;

    public bool finishedAction { get; private set; }
    public void FinishedAction()
    {
        finishedAction = true;
    }
    public void ResetAction()
    {
        finishedAction = false;
    }

    public void DoEvent(int index)
    {
        //doOnEvent.Invoke();
        test[index].Invoke();
    }

    private void Start()
    {
        finishedAction = false;
    }

    private void Update()
    {
        //Debug.Log(finishedStrikeAction);
    }
}
