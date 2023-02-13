using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointManager : MonoBehaviour, ISaveable
{
    public static CheckPointManager instance;

    public bool isLoadingCheckPoint { get; private set; }

    [SerializeField] string sceneOfLastCheckPoint;

    void Start()
    {
        instance = this;
        //sceneOfLastCheckPoint = "Scene1";
        if (FindObjectOfType<ProgressManager>().HasProgress(ProgressEnum.FinishedManusianFight) == false)
        {
            Debug.LogError("Hello");
            sceneOfLastCheckPoint = "Scene1";
        }
        LoadCheckPoint();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(sceneOfLastCheckPoint);
    }

    public string GetLastCheckPoint()
    {
        return sceneOfLastCheckPoint;
    }

    public void UpdateCheckPoint(string newSceneOfCheckPoint)
    {
        sceneOfLastCheckPoint = newSceneOfCheckPoint;
        Debug.LogError("After: " + sceneOfLastCheckPoint);
    }

    [ContextMenu("Load check-point")]
    public void LoadCheckPoint()
    {
        Debug.LogError(sceneOfLastCheckPoint);

        if (gameObject.scene.name != sceneOfLastCheckPoint)
        {
            isLoadingCheckPoint = true;
            SceneManager.LoadScene(sceneOfLastCheckPoint);
            return;
        }
        //Debug.LogError(sceneOfLastCheckPoint);
    }

    public void CheckPointLoaded()
    {
        isLoadingCheckPoint = false;
    }

    public object CaptureState()
    {
        return new SaveData
        {
            sceneOfLastCheckPointSave = sceneOfLastCheckPoint
        };
    }

    public void RestoreState(object state)
    {
        var saveData = (SaveData)state;
        sceneOfLastCheckPoint = saveData.sceneOfLastCheckPointSave;
        //LoadCheckPoint();
    }

    [System.Serializable]
    private struct SaveData
    {
        public string sceneOfLastCheckPointSave;
    }
}
