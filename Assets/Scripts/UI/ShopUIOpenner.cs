using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIOpenner : MonoBehaviour, IIngameUI
{
    [SerializeField] private KeyCode openKeyCode;
    [SerializeField] private KeyCode closeKeyCode;
    [SerializeField] private bool UIUsed = false;
    [SerializeField] private ProgressEnum requiredProgress;
    public bool UseUI(GameObject panel)
    {
        if(Input.GetKeyDown(openKeyCode) && (requiredProgress == ProgressEnum.None || ProgressManager.instance.HasProgress(requiredProgress)))
        {
            if(UIUsed == false)
            {
                panel.SetActive(true);
                UIUsed = true;
            }
        }
        else if(Input.GetKeyDown(closeKeyCode))
        {
            if(UIUsed == true)
            {
                panel.SetActive(false);
                UIUsed = false;
            }    
        }
        return UIUsed;
    }
}
