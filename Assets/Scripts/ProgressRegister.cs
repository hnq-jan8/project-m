using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressRegister : MonoBehaviour
{
    [SerializeField] private Progress progress;


    public void RegisterProgress()
    {
        ProgressManager.instance.AddProgress(progress);
    }
}
