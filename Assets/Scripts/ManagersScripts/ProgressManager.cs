using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProgressManager : MonoBehaviour, ISaveable
{
    public static ProgressManager instance;

    [SerializeField] private SerializableList<Progress> progresses;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void AddProgress(Progress p)
    {
        progresses.list.Add(p);
    }

    public List<Progress> GetProgressList()
    {
        return progresses.list;
    }

    public bool HasProgress(ProgressEnum progressName)
    {
        //Debug.Log(progresses.Count);
        foreach(Progress p in progresses.list)
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
        Debug.LogError("Progress Manager data: " + JsonUtility.ToJson(progresses));
        return new SaveData
        {
            progressJson = JsonUtility.ToJson(progresses)
        };
    }

    public void RestoreState(object state)
    {
        Debug.LogError("Restoring state for: " + this.gameObject.name);
        var saveData = (SaveData)state;
        JsonUtility.FromJsonOverwrite(saveData.progressJson, progresses);
        Debug.LogError(saveData.progressJson);
    }

    [Serializable]
    private struct SaveData
    {
        public string progressJson;
    }
}
