using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour, ISaveable
{
    public static ShopManager instance;
    [SerializeField] private List<ShopData> shopsData;

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

    [System.Serializable]
    private struct SaveData
    {
        public string shopsDataJson;
    }
}
