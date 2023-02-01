using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    [SerializeField] private bool canInteract;

    public UnityEvent OnLeverSwitched;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canInteract == true && Input.GetKeyDown(KeyCode.Space))
        {
            OnLeverSwitched.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(ProgressManager.instance.HasProgress(ProgressEnum.ActivateElevator) == false)
        {
            if(collision.CompareTag("Player"))
            {
                canInteract = true;
            }
        }
        else
        {
            canInteract = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
        }
    }
}
