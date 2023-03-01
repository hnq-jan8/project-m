using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShopManager : MonoBehaviour, ISaveable
{
    public static ShopManager instance;
    [SerializeField] private SerializableList<ShopData> shopsData;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public object CaptureState()
    {
        return new SaveData
        {
            shopsDataJson = JsonUtility.ToJson(shopsData)
        };
    }

    public void RestoreState(object state)
    {
        var saveData = (SaveData)state;
        JsonUtility.FromJsonOverwrite(saveData.shopsDataJson, shopsData);
    }

    [Serializable]
    private struct SaveData
    {
        public string shopsDataJson;
    }
}
