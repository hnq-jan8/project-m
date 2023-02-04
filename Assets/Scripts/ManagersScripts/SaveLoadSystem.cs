using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadSystem : MonoBehaviour
{
    private string SavePath => $"{Application.persistentDataPath}/save.txt";


    [ContextMenu("Save")]
    public void Save()
    {
        var state = LoadFile();
        CaptureState(state);
        SaveFile(state);
    }

    [ContextMenu("Load")]
    public void Load()
    {
        var state = LoadFile();
        RestoreState(state);
    }

    void SaveFile(object state)
    {
        using(var stream = File.Open(SavePath, FileMode.Create))
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, state);
        }
    }

    Dictionary<string, object> LoadFile()
    {
        if(!File.Exists(SavePath))
        {
            return new Dictionary<string, object>();
        }

        using(FileStream stream = File.Open(SavePath, FileMode.Open))
        {
            var formatter = new BinaryFormatter();
            return (Dictionary<string, object>)formatter.Deserialize(stream);
        }
    }

    //Capture all data of all SaveableObjects in the scene.
    //Make every SaveableObject call 'CaptureState()' function and then add the return value into a dictionary

    //SaveableObject has Dictionary storing data in a gameobject
    //SaveLoadSystem has Dictionary storing all SaveableObjects and their Dictionary
    void CaptureState(Dictionary<string, object> state)     
    {
        foreach(var saveable in FindObjectsOfType<SaveableObject>())
        {
            state[saveable.Id] = saveable.CaptureState();
        }
    }

    void RestoreState(Dictionary<string, object> state)
    {
        foreach(var saveable in FindObjectsOfType<SaveableObject>())
        {
            if(state.TryGetValue(saveable.Id, out object value))
            {
                saveable.RestoreState(value);
            }
        }
    }
}
