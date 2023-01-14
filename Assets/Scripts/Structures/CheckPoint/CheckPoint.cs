using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private string sceneOfCheckPoint;

    [SerializeField] private bool canUseCheckPoint;

    [SerializeField] private KeyCode useCheckPointKey;

    void OnEnable()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneOfCheckPoint = gameObject.scene.name;
        if (CheckPointManager.instance.isLoadingCheckPoint == true)
        {
            Debug.Log("A");
            PlayerSingleton.instance.transform.position = transform.position;
            PlayerSingleton.instance.GetComponentInChildren<PlayerHeal>().FullHeal();
            CheckPointManager.instance.CheckPointLoaded();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CheckPointManager.instance.GetLastCheckPoint());
        //Debug.Log(PlayerWalletManager.instance.getMoney());
        if (canUseCheckPoint == true && Input.GetKeyDown(useCheckPointKey))
        {
            CheckPointManager.instance.UpdateCheckPoint(sceneOfCheckPoint);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canUseCheckPoint = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canUseCheckPoint = false;
    }
}
