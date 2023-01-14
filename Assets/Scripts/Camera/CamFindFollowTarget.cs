using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamFindFollowTarget : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] GameObject targetToFollow;
    private void Start()
    {
        FindTargetToFollow();
    }

    private void OnEnable()
    {
        //FindTargetToFollow();
    }

    public void FindTargetToFollow()
    {
        //Debug.Log("abc");

        targetToFollow = FindObjectOfType<PlayerSingleton>().gameObject;

        virtualCamera.Follow = targetToFollow.transform;
        //Debug.Log(virtualCamera.Follow == targetToFollow.transform);
    }

   /* private void Update()
    {
        targetToFollow = FindObjectOfType<PlayerSingleton>().gameObject;
        virtualCamera.Follow = targetToFollow.transform;
        Debug.Log(targetToFollow.name);
    }*/
}
