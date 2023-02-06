using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveableObject : MonoBehaviour
{
    [SerializeField] private string id = string.Empty;

    public string Id => id;

    [ContextMenu("Generate ID")]
    void GenerateID()
    {
        id = System.Guid.NewGuid().ToString();
    }

    //Capture the data of all objects of type Isaveable
    public object CaptureState()
    {
        //Dictionary to store all Isaveable objects and its data (of this gameobject)
        var state = new Dictionary<string, object>();   //A gameobject can have one or more Isaveable objects in it => use Dictionar (with 'string' is the name of the Isaveable object and 'object' is the data of that Isaveable)
        
        foreach(var saveable in GetComponentsInChildren<ISaveable>())
        {
            state[saveable.GetType().ToString()] = saveable.CaptureState();
        }

        return state;
    }

    public void RestoreState(object state)
    {
        var stateDictionary = (Dictionary<string, object>)state;

        foreach(var saveable in GetComponentsInChildren<ISaveable>())
        {
            string typeName = saveable.GetType().ToString();
            if(stateDictionary.TryGetValue(typeName, out object value))
            {
                saveable.RestoreState(value);
            }
        }
    }
}
