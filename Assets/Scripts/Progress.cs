using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Progress
{
    [SerializeField] private ProgressEnum progressName;

    public ProgressEnum GetProgressName()
    {
        return progressName;
    }
}
