using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpMenu : MonoBehaviour
{
    //-------------------------------------------//
    //This class makes an object an Pop up menu
    //Pop up menu can: 
    //+ Open other pop up menus with its buttons --include-> close itself

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenOtherPopUpMenu(GameObject menu)
    {
        menu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
