using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIOpenner : MonoBehaviour
{
    [SerializeField] GameObject panel;
    private bool isUsingUI;

    public IIngameUI ingameUI;

    // Start is called before the first frame update
    void Start()
    {
        //panel.SetActive(false);
        ingameUI = GetComponent<IIngameUI>();
        isUsingUI = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ingameUI == null)
        {
            Debug.LogError("You have to feed the UIOpenner a UI");
        }
        if(UIManager.playerIsUsingUI == false || UIManager.uiInUse == this)
        {
            isUsingUI = ingameUI.UseUI(panel);
        }
    }

    public bool IsUsingUI()
    {
        return isUsingUI;
    }
}
