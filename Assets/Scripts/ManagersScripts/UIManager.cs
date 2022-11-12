using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static bool PlayerisUsingUI;

    [SerializeField] private UIOpenner[] ingameUIs;

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
                PlayerisUsingUI = true;
                return;
            }
        }
        PlayerisUsingUI = false;
    }
}
