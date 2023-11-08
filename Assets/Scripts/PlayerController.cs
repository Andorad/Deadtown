using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float normalSpeed;
    private float actualSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        actualSpeed = normalSpeed;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * actualSpeed, movement.y * actualSpeed);
    }
}
