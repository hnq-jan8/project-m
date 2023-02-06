using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasFindUICam : MonoBehaviour
{
    public Camera uiCamera;

    // Start is called before the first frame update
    void Start()
    {
        FindUICam();
    }

    public void FindUICam()
    {
        if (GameObject.Find("UI Camera").GetComponent<Camera>() != null) Debug.LogError("Found UI cam");

        uiCamera = GameObject.Find("UI Camera").GetComponent<Camera>();
        GetComponent<Canvas>().worldCamera = uiCamera;
    }
}
