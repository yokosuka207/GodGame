using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMove : MonoBehaviour
{
    // プレイヤーInfo
    private Rigidbody2D rb;                 // Rigidbody2D
    private CapsuleCollider2D cc;           // BoxCollider2D
    private PlayerLevel pl;                 // PlayerLevelクラス
    private bool isMove = true;             // 移動Flag

    // プレイヤー速度
    [SerializeField] private Vector2 maxMove = new Vector2(2.0f, 2.0f);
    private Vector2 move;                   // 入力方向の情報
    private Vector2 movement;               // 入力方向の情報保持
    private float   moveSpeed = 100.0f;     // 
    private float   moveUp;                 // レベルアップした時に足すスピード
 
    // Block
    [SerializeField] private Tilemap tileMap;       // タイルマップ
    [SerializeField] private Tile blockTile;        // タイルマップのブロック

    // カメラ
    private GameObject ca;
    private CameraManager cm;

    private void Start()
    {
        // Info取得
        rb = this.GetComponent<Rigidbody2D>();          // Rigidbody2D取得
        cc = this.GetComponent<CapsuleCollider2D>();    // CapsuleCollider2D取得
        pl = GetComponent<PlayerLevel>();               // PlayerLevelスクリプト取得

        // カメラの取得
        ca = GameObject.Find("Main Camera");
        cm = ca.GetComponent<CameraManager>();
    }

    void Update()
    {
        // 現在の入力方向取得
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        movement = new Vector2(move.x, move.y);

        // 正規化
        movement.Normalize();
        
        // レベルに応じたスピード変更
        UpSpeed();

        // 滑らないようにする
        if(movement == Vector2.zero)
        {
            movement = Vector2.zero;
        }

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
        if (isMove && cm.Returncam())
        {
            // プレイヤーに力を加える
            rb.AddForce(movement * moveSpeed);

            // maxSpeedをこえないように
            if (rb.velocity.x >= maxMove.x)
            {
                rb.velocity = new Vector2(movement.x * (maxMove.x + moveUp), rb.velocity.y);
            }
            if (rb.velocity.x <= -maxMove.x)
            {
                rb.velocity = new Vector2(movement.x * (maxMove.x + moveUp), rb.velocity.y);
            }
            if (rb.velocity.y >= maxMove.y)
            {
                rb.velocity = new Vector2(rb.velocity.x, movement.y * (maxMove.y + moveUp));
            }
            if (rb.velocity.y <= -maxMove.y)
            {
                rb.velocity = new Vector2(rb.velocity.x, movement.y * (maxMove.y + moveUp));
            }

            if(move.x == 0)
            { 
                rb.velocity = new Vector2(0.0f, rb.velocity.y);
            }
            if (move.y == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0.0f);
            }
        }
        // カメラからの停止命令がでている場合
        else if (!cm.Returncam())
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // ブロック
        if (collision.gameObject.CompareTag("Block"))
        {
            // パルクール (Fキー & レベル10)
            if (Input.GetKey(KeyCode.F) && (pl.GetLevel() >= 10))
            {
                // 方向キーが入力されてる
                if (movement != Vector2.zero)
                {
                    // 衝突前の入力方向へ移動
                    rb.velocity = new Vector2(movement.x, movement.y);
                    isMove = false;
                    cc.isTrigger = true;        // trueですり抜けさせる
                }
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
            cc.isTrigger = false;
            isMove = true;
        }
    }

    private void UpSpeed()
    {
        // レベルに応じたスピード計算
        moveUp = pl.GetLevel() * 0.1f;
    }
}