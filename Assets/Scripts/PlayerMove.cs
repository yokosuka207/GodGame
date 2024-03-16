using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float maxMoveX = 2.0f;
    [SerializeField] private float maxMoveY = 2.0f;

    private Rigidbody2D rb;
    private float moveX;
    private float moveY;
    private float moveSpeed = 100.0f;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveX, moveY);

        movement.Normalize();
    }

    private void FixedUpdate()
    {
        // ƒvƒŒƒCƒ„[‚É—Í‚ð‰Á‚¦‚é
        rb.AddForce(movement * moveSpeed);

        if (rb.velocity.x >= maxMoveX)
        {
            rb.velocity = new Vector2(movement.x * maxMoveX, rb.velocity.y);
        }
        if (rb.velocity.x <= -maxMoveX)
        {
            rb.velocity = new Vector2(movement.x * maxMoveX, rb.velocity.y);
        }
        if (rb.velocity.y >= maxMoveY)
        {
            rb.velocity = new Vector2(rb.velocity.x, movement.y * maxMoveY);
        }
        if (rb.velocity.y <= -maxMoveY)
        {
            rb.velocity = new Vector2(rb.velocity.x, movement.y * maxMoveY);
        }

        if (moveX == 0)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }
        if (moveY == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0.0f);
        }
    }
}
