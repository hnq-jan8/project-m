using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamFindFollowTarget : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] GameObject targetToFollow;
    private void Awake()
    {
        targetToFollow = FindObjectOfType<PlayerSingleton>().gameObject;

        virtualCamera.Follow = targetToFollow.transform;
    }
}
