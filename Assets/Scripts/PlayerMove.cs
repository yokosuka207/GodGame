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
    private PlayerTilePosition pt;          // PlayerTilePositionクラス
    private bool isMove = true;             // 移動Flag
    private bool isPar = false;             // パルクールFlags
    private GameObject closeObject;         // 一番近いオブジェクト

    public GameObject brushObject;

    // プレイヤー速度
    [SerializeField] private Vector2 maxMove = new Vector2(2.0f, 2.0f);     // 移動スピード
    [SerializeField] private Vector2 parSpeed = new Vector2(1.0f, 1.0f);    // パルクール中スピード
    private Vector2 move;                   // 入力方向の情報
    private Vector2 movement;               // 入力方向の情報保持
    private float moveSpeed = 100.0f;       // 
    private float moveUp;                   // レベルアップした時に足すスピード

    // Block
    [SerializeField] private Tilemap tileMap;       // タイルマップ
    [SerializeField] private Tile blockTile;        // タイルマップのブロック
    private Vector3Int tilePos;                     // TilePosition

    // カメラ
    private GameObject ca;
    private cameraManager cm;

    private void Start()
    {
        // Info取得
        rb = this.GetComponent<Rigidbody2D>();          // Rigidbody2D取得
        cc = this.GetComponent<CapsuleCollider2D>();    // CapsuleCollider2D取得
        pl = this.GetComponent<PlayerLevel>();               // PlayerLevelスクリプト取得
        pt = this.GetComponent<PlayerTilePosition>();        // PlayerTilePositionスクリプト取得

        // カメラの取得
        ca = GameObject.Find("Main Camera");
        cm = ca.GetComponent<cameraManager>();
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
        if (movement == Vector2.zero)
        {
            movement = Vector2.zero;
        }
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

            if (move.x == 0)
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
            if(movement.x == movement.y)
            rb.AddForce(-movement * moveSpeed);

            // パルク―ル中止まらない
            if (cc.isTrigger != true)
                rb.velocity = Vector2.zero;
        }

        // ブロック配置
        if (tilePos != pt.GetTilePos())
        {
            if (Input.GetKey(KeyCode.Space))
            {
                // なんかブロックが左一列ずれてるから
                Vector3Int grid = tileMap.WorldToCell(tilePos);
                grid += new Vector3Int(1, 0, 0);
                Instantiate(brushObject, grid, Quaternion.identity);
            }
        }

        tilePos = pt.GetTilePos();

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // ブロック
        if (collision.gameObject.CompareTag("Block"))
        {
            // パルクール (Fキー & レベル10)
            if (Input.GetKey(KeyCode.LeftShift) && (pl.GetLevel() >= 10))
            {
                // 方向キーが入力されてる
                if (movement != Vector2.zero)
                {
                    //isPar = true;
                    // 衝突前の入力方向へ移動
                    rb.velocity = new Vector2(movement.x * parSpeed.x, movement.y * parSpeed.y);
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
            if (!FindObject("Block"))
            {
                //isPar = false;
                // 一度停止、Trigger,isMove,isParを戻す
                rb.velocity = Vector2.zero;
                cc.isTrigger = false;
                isMove = true;
            }            
        }
    }

    private void UpSpeed()
    {
        // レベルに応じたスピード計算
        moveUp = pl.GetLevel() * 0.1f;
    }

    // 一番近いオブジェクトタグを見つける(タイルを見つける)
    private GameObject FindObject(string Tag)
    {
        // ターゲットタグのオブジェクトを持つコライダーを見つける
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 0.1f);

        foreach (Collider2D collider in colliders)
        {
            // タグが一致するか確認
            if (collider.CompareTag("Block"))
            {
                // ターゲットとの距離を計算
                float distance = Vector2.Distance(this.transform.position, collider.transform.position);

                // 最も近いオブジェクトを更新
                if (distance < Mathf.Infinity)
                {
                    closeObject = collider.gameObject;
                    return closeObject;
                }
                else
                {
                    closeObject = null;
                }
            }
        }

        return null;
    }
}