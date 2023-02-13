using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour, ISaveable
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
        //Debug.Log(progresses.Count);
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

    public object CaptureState()
    {
        return new SaveData
        {
            progressJson = JsonUtility.ToJson(progresses)
        };
    }

    public void RestoreState(object state)
    {
        var saveData = (SaveData)state;
        JsonUtility.FromJsonOverwrite(saveData.progressJson, progresses);
    }

    [System.Serializable]
    private struct SaveData
    {
        public string progressJson;
    }
}
