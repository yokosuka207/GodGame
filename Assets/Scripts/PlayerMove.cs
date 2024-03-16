using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMove : MonoBehaviour
{
    // プレイヤーInfo
    private Rigidbody2D rb;                 // Rigidbody2D
    private BoxCollider2D bc;               // BoxCollider2D
    private Vector2 nowVelocity;            // 現在Velocity
    private bool isMove = true;             // 移動Flag
    private bool isPar = false;             // パルクールFlag

    // プレイヤー速度
    [SerializeField] private Vector2 maxMove = new Vector2(2.0f, 2.0f);
    private Vector2 move;                   // 入力方向の情報
    private Vector2 movement;               // 入力方向の情報保持
    private float   moveSpeed = 100.0f;       // 
 

    // Block
    [SerializeField] private Tilemap tileMap;       // タイルマップ
    [SerializeField] private Tile blockTile;        // タイルマップのブロック

    // レイヤー
    private int layerNumber = 0;


    private void Start()
    {
        // Rigidbody2D,BoxCollider2Dの取得
        rb = this.GetComponent<Rigidbody2D>();
        bc = this.GetComponent<BoxCollider2D>();

         // 現在のレイヤー取得
         layerNumber = gameObject.layer;
    }

    void Update()
    {
        // 現在の入力方向取得
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        movement = new Vector2(move.x, move.y);

        // 正規化
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
        // 移動
        if (isMove)
        {
            // プレイヤーに力を加える
            rb.AddForce(movement * moveSpeed);

            // maxSpeedをこえないように
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

            //if (move.x == 0)
            //{
            //    rb.velocity = new Vector2(0.0f, rb.velocity.y);
            //}
            //if (move.y == 0)
            //{
            //    rb.velocity = new Vector2(rb.velocity.x, 0.0f);
            //}
        }

        // 現在のVelocity取得
        nowVelocity = new Vector2(rb.velocity.x, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ブロック
        if (collision.gameObject.CompareTag("Block"))
        {
            // パルクール
            if (Input.GetKey(KeyCode.F))
            {
                // 衝突前の入力方向へ移動
                rb.velocity = new Vector2(nowVelocity.x, nowVelocity.y);
                isMove = false;
                bc.isTrigger = true;        // trueですり抜けさせる

                Debug.Log("あああああ");
            }

            // パルクール
            if (isPar)
            {


                //gameObject.layer = LayerMask.NameToLayer("Through");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // ブロック
        if (collision.gameObject.CompareTag("Block"))
        {
            // 一度停止、Trigger,isMove,isParを戻す
            rb.velocity = Vector2.zero;
            bc.isTrigger = false;
            isMove = true;
            isPar = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
            Debug.Log("離れてる");
        }
    }
}
