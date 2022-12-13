using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camshake : MonoBehaviour
{
    public CinemachineImpulseSource camShake;

    public void PlayCamShake()
    {
        camShake.GenerateImpulse();
    }
}
