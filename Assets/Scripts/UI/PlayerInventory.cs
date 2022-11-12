using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour, IIngameUI
{
    [SerializeField] private KeyCode keyCode;
    [SerializeField] private bool UIUsed = false;
    public bool UseUI(GameObject panel)
    {
        if (Input.GetKeyDown(keyCode))
        {
            //Debug.LogError("Hit E");
            if(UIUsed == false)
            {
                panel.SetActive(true);
                UIUsed = true;
            }
            else
            {
                panel.SetActive(false);
                UIUsed = false;
            }
        }
        return UIUsed;
    }
}
