using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager instance;

    [SerializeField] private List<Progress> progresses = new List<Progress>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void AddProgress(Progress p)
    {
        progresses.Add(p);
    }

    public List<Progress> GetProgressList()
    {
        return progresses;
    }

    public bool HasProgress(ProgressEnum progressName)
    {
        Debug.Log(progresses.Count);
        foreach(Progress p in progresses)
        {
            Debug.Log(p.GetProgressName() + " - " + progressName);
            if (p.GetProgressName().Equals(progressName))
            {
                return true;
            }
        }
        return false;
    }
}
