using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUIOpenner : MonoBehaviour, IIngameUI
{
    [SerializeField] private KeyCode openKeyCode;
    [SerializeField] private KeyCode closeKeyCode;
    [SerializeField] private bool UIUsed = false;
    public bool UseUI(GameObject panel)
    {
        if(Input.GetKeyDown(openKeyCode))
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
