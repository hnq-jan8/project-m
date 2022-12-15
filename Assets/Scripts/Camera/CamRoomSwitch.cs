using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRoomSwitch : MonoBehaviour
{
    [SerializeField] private GameObject virtualCam;

    private void Start()
    {
        virtualCam = transform.GetChild(0).gameObject;
        virtualCam.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            virtualCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.isTrigger)
        {
            virtualCam.SetActive(false);
        }
    }
}
