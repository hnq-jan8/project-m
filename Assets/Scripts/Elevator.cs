using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform elevatorswitch;
    [SerializeField] private Transform downpos;
    [SerializeField] private Transform upperpos;

    public float speed;
    bool iselevatordown;
    void Start()
    {
        player = FindObjectOfType<PlayerSingleton>().transform;
    }

    
    void FixedUpdate()
    {
        StartElevator();
    }

    void StartElevator()
    {
        if (ProgressManager.instance.HasProgress(ProgressEnum.ActivateElevator) == false)
        {
            Debug.Log("Ngu");
            return;
        }
        if(Vector3.Distance(player.position,elevatorswitch.position) < 3f && Input.GetKeyDown(KeyCode.Space))
        {
            if(transform.position.y <= downpos.position.y)
            {
                iselevatordown = true;
            }
            else if(transform.position.y >= upperpos.position.y)
            {
                iselevatordown = false;
            }
        }

        if (iselevatordown)
        {
            transform.position = Vector3.MoveTowards(transform.position, upperpos.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, downpos.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
            GameObject.DontDestroyOnLoad(collision.gameObject);
        }
    }

}
