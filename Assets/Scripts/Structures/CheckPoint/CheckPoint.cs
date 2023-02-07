using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private bool interactable;

    [SerializeField] private string sceneOfCheckPoint;

    [SerializeField] private bool canUseCheckPoint;

    [SerializeField] private KeyCode useCheckPointKey;

    void OnEnable()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerSingleton instance = PlayerSingleton.instance;
        HealthUI healthUI = FindObjectOfType<HealthUI>();
        sceneOfCheckPoint = gameObject.scene.name;
        if (CheckPointManager.instance.isLoadingCheckPoint == true)
        {
            Debug.Log("A");
            instance.transform.position = transform.position;
            instance.GetComponentInChildren<PlayerHeal>().FullHeal();
            instance.GetComponent<Life>().ResetTint();
            //healthUI.ResetHP();
            //healthUI.InitHP();
            CheckPointManager.instance.CheckPointLoaded();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(CheckPointManager.instance.GetLastCheckPoint());
        //Debug.Log(PlayerWalletManager.instance.getMoney());
        if (canUseCheckPoint == true && Input.GetKeyDown(useCheckPointKey) && interactable == true)
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
