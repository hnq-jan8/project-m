using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMapObjectActivate : MonoBehaviour
{
    [SerializeField] private GameObject mapObject;
    [SerializeField] private GameObject mapUI;
    [SerializeField] private MapUICameraMoving mapUICameraMoving;
    [SerializeField] private MapUICameraZoom mapUICameraZoom;

    // Start is called before the first frame update
    void Start()
    {
        mapUI = FindObjectOfType<PlayerMap>().transform.GetChild(0).gameObject;
        mapObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(mapUI.activeInHierarchy == true)
        {
            mapObject.SetActive(true);
        }
        else
        {
            mapObject.SetActive(false);
            mapUICameraMoving.ResetPos();
            mapUICameraZoom.ResetZoom();
        }
    }
}
