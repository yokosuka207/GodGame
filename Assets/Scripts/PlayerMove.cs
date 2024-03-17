using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMove : MonoBehaviour
{
    // �v���C���[Info
    private Rigidbody2D rb;                 // Rigidbody2D
    private CapsuleCollider2D cc;           // BoxCollider2D
    private PlayerLevel pl;                 // PlayerLevel�N���X
    private bool isMove = true;             // �ړ�Flag

    // �v���C���[���x
    [SerializeField] private Vector2 maxMove = new Vector2(2.0f, 2.0f);
    private Vector2 move;                   // ���͕����̏��
    private Vector2 movement;               // ���͕����̏��ێ�
    private float   moveSpeed = 100.0f;     // 
    private float   moveUp;                 // ���x���A�b�v�������ɑ����X�s�[�h
 
    // Block
    [SerializeField] private Tilemap tileMap;       // �^�C���}�b�v
    [SerializeField] private Tile blockTile;        // �^�C���}�b�v�̃u���b�N

    // �J����
    private GameObject ca;
    private CameraManager cm;

    private void Start()
    {
        // Info�擾
        rb = this.GetComponent<Rigidbody2D>();          // Rigidbody2D�擾
        cc = this.GetComponent<CapsuleCollider2D>();    // CapsuleCollider2D�擾
        pl = GetComponent<PlayerLevel>();               // PlayerLevel�X�N���v�g�擾

        // �J�����̎擾
        ca = GameObject.Find("Main Camera");
        cm = ca.GetComponent<CameraManager>();
    }

    void Update()
    {
        // ���݂̓��͕����擾
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        movement = new Vector2(move.x, move.y);

        // ���K��
        movement.Normalize();
        
        // ���x���ɉ������X�s�[�h�ύX
        UpSpeed();

        // ����Ȃ��悤�ɂ���
        if(movement == Vector2.zero)
        {
            movement = Vector2.zero;
        }

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
        if (isMove && cm.Returncam())
        {
            // �v���C���[�ɗ͂�������
            rb.AddForce(movement * moveSpeed);

            // maxSpeed�������Ȃ��悤��
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
        // �J��������̒�~���߂��łĂ���ꍇ
        else if (!cm.Returncam())
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // �u���b�N
        if (collision.gameObject.CompareTag("Block"))
        {
            // �p���N�[�� (F�L�[ & ���x��10)
            if (Input.GetKey(KeyCode.F) && (pl.GetLevel() >= 10))
            {
                // �����L�[�����͂���Ă�
                if (movement != Vector2.zero)
                {
                    // �ՓˑO�̓��͕����ֈړ�
                    rb.velocity = new Vector2(movement.x, movement.y);
                    isMove = false;
                    cc.isTrigger = true;        // true�ł��蔲��������
                }
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
            cc.isTrigger = false;
            isMove = true;
        }
    }

    private void UpSpeed()
    {
        // ���x���ɉ������X�s�[�h�v�Z
        moveUp = pl.GetLevel() * 0.1f;
    }
}