using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMove : MonoBehaviour
{
    // プレイヤー速度
    [SerializeField] private Vector2 maxMove = new Vector2(2.0f, 2.0f);
    public bool isMove = true;
    private Rigidbody2D rb;
    private float moveX;
    private float moveY;
    private float moveSpeed = 100.0f;
    private Vector2 movement;
    Vector2 nowVelocity;
    // Block
    [SerializeField] private Tilemap tileMap;
    [SerializeField] private Tile blockTile;

    // レイヤー
    private int layerNumber = 0;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // 現在のレイヤー取得
        layerNumber = gameObject.layer;
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveX, moveY);

        movement.Normalize();

        // Block配置
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3Int grid = tileMap.WorldToCell(transform.position);
        //    tileMap.SetTile(grid, blockTile);
        //}
    }

    private void FixedUpdate()
    {
        // プレイヤーに力を加える
        if (isMove)
        {
            rb.AddForce(movement * moveSpeed);

            if (rb.velocity.x >= maxMove.x)
            {
                rb.velocity = new Vector2(movement.x * maxMove.x, rb.velocity.y);
            }
            if (rb.velocity.x <= -maxMove.x)
            {
                rb.velocity = new Vector2(movement.x * maxMove.x, rb.velocity.y);
            }
            if (rb.velocity.y >= maxMove.y)
            {
                rb.velocity = new Vector2(rb.velocity.x, movement.y * maxMove.y);
            }
            if (rb.velocity.y <= -maxMove.y)
            {
                rb.velocity = new Vector2(rb.velocity.x, movement.y * maxMove.y);
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

        nowVelocity = new Vector2(rb.velocity.x, rb.velocity.y);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            rb.velocity = new Vector2(nowVelocity.x, nowVelocity.y);
            Debug.Log(rb.velocity);
            isMove = false;
            gameObject.layer = LayerMask.NameToLayer("Through");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            gameObject.layer = layerNumber;
        }
    }
}
