using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMove : MonoBehaviour
{
    // �v���C���[Info
    private Rigidbody2D rb;                 // Rigidbody2D
    private BoxCollider2D bc;               // BoxCollider2D
    private Vector2 nowVelocity;            // ����Velocity
    private bool isMove = true;             // �ړ�Flag
    private bool isPar = false;             // �p���N�[��Flag

    // �v���C���[���x
    [SerializeField] private Vector2 maxMove = new Vector2(2.0f, 2.0f);
    private Vector2 move;                   // ���͕����̏��
    private Vector2 movement;               // ���͕����̏��ێ�
    private float   moveSpeed = 100.0f;       // 
 

    // Block
    [SerializeField] private Tilemap tileMap;       // �^�C���}�b�v
    [SerializeField] private Tile blockTile;        // �^�C���}�b�v�̃u���b�N

    // ���C���[
    private int layerNumber = 0;


    private void Start()
    {
        // Rigidbody2D,BoxCollider2D�̎擾
        rb = this.GetComponent<Rigidbody2D>();
        bc = this.GetComponent<BoxCollider2D>();

         // ���݂̃��C���[�擾
         layerNumber = gameObject.layer;
    }

    void Update()
    {
        // ���݂̓��͕����擾
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        movement = new Vector2(move.x, move.y);

        // ���K��
        movement.Normalize();

        // Block�z�u
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3Int grid = tileMap.WorldToCell(transform.position);
        //    tileMap.SetTile(grid, blockTile);
        //}
    }

    private void FixedUpdate()
    {
        // �ړ�
        if (isMove)
        {
            // �v���C���[�ɗ͂�������
            rb.AddForce(movement * moveSpeed);

            // maxSpeed�������Ȃ��悤��
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

        // ���݂�Velocity�擾
        nowVelocity = new Vector2(rb.velocity.x, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �u���b�N
        if (collision.gameObject.CompareTag("Block"))
        {
            // �p���N�[��
            if (Input.GetKey(KeyCode.F))
            {
                // �ՓˑO�̓��͕����ֈړ�
                rb.velocity = new Vector2(nowVelocity.x, nowVelocity.y);
                isMove = false;
                bc.isTrigger = true;        // true�ł��蔲��������

                Debug.Log("����������");
            }

            // �p���N�[��
            if (isPar)
            {


                //gameObject.layer = LayerMask.NameToLayer("Through");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // �u���b�N
        if (collision.gameObject.CompareTag("Block"))
        {
            // ��x��~�ATrigger,isMove,isPar��߂�
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
            Debug.Log("����Ă�");
        }
    }
}
