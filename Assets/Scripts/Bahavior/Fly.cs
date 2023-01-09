using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MovementBehavior
{
    IFlyInput flyInput;

    [SerializeField] float flySpeed;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if(GetComponent<IFlyInput>() == null)
        {
            Debug.Log("Please insert a Fly Input for the game object: " + this.gameObject.name);
        }
        else
        {
            flyInput = GetComponent<IFlyInput>();
        }
    }

    public void FlyTowardsTarget()
    {
        rb.MovePosition(Vector2.MoveTowards(movingObject.transform.position, flyInput.target, flySpeed * Time.deltaTime));
    }

    // Update is called once per frame
/*    void Update()
    {
        
    }*/
}
