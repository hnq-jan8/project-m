using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUICameraMoving : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 initPos = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);
        transform.position = initPos;
    }

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void ResetPos()
    {
        Vector3 resetPos = new Vector3(playerPos.position.x, playerPos.position.y, transform.position.z);
        transform.position = resetPos;
    }
}
