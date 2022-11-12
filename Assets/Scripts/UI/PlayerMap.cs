using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMap : MonoBehaviour, IIngameUI
{
    [SerializeField] private KeyCode tempKeyCode;
    [SerializeField] private KeyCode keyCode;
    [SerializeField] private bool UIUsed = false;
    public bool UseUI(GameObject panel)
    {
        if (Input.GetKeyDown(keyCode))
        {
            if (UIUsed == false)
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

        if (Input.GetKeyDown(tempKeyCode))
        {
            if (UIUsed == false)
            {
                panel.SetActive(true);
                UIUsed = true;
            }
        }
        if(Input.GetKeyUp(tempKeyCode))
        {
            panel.SetActive(false);
            UIUsed = false;
        }
        return UIUsed;
    }
}
