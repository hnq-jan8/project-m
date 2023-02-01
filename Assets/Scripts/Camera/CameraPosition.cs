using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraPosition : PlayerBehavior
{
    [SerializeField] Transform theTarget;
    [SerializeField] CinemachineVirtualCamera virtualCamera;

    [Header("Default stats")]   //This is the stats where the player stays and looking right
    [SerializeField] float screenX = 0.45f;
    [SerializeField] float screenY = 0.73f;

    // Start is called before the first frame update
    void Start()
    {
        FindPlayer();
    }

    public void FindPlayer()
    {
        theTarget = FindObjectOfType<PlayerSingleton>().transform;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(UIUsingCheck() == false)
        {
            CameraLookAhead();

            CameraLookUpDown();
        }
    }

    void CameraLookAhead()
    {
        if (theTarget.localScale.x < 0)     //looking left -> camera lean to the right
        {
            virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = 0.55f;
        }
        else                                //looking right -> camera get back to default position
        {
            virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenX = screenX;
        }
    }

    void CameraLookUpDown()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = screenY + 0.35f;
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = screenY;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = screenY - 0.35f;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = screenY;
        }
    }
}
