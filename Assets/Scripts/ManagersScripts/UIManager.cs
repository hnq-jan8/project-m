using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static bool playerIsUsingUI;

    public static UIOpenner uiInUse;

    [SerializeField] private UIOpenner[] ingameUIs;

    void Start()
    {
        ingameUIs = FindObjectsOfType<UIOpenner>();
    }

    // Update is called once per frame
    void Update()
    {
        UIUseCheck();
    }

    void UIUseCheck()
    {
        foreach(UIOpenner ui in ingameUIs)
        {
            if(ui.IsUsingUI() == true)
            {
                playerIsUsingUI = true;
                uiInUse = ui;
                return;
            }
        }
        playerIsUsingUI = false;
        uiInUse = null;
    }
}
