using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10; //�G�l�~�[�̍ő�w���X
    public int currentHealth; //���݂̃w���X

    bool isBlockCollided = false;
    bool isFlameCollided = false;

    void Start()
    {
        currentHealth = maxHealth; //�ő�w���X�ŏ�����
    }

    void OnTriggerStay2D(Collider2D other)
    {

        // �Փ˂����I�u�W�F�N�g���I�u�W�F�N�g2(Block)�ł���ꍇ
        if (other.gameObject.CompareTag("Block"))
        {
            isBlockCollided = true;
        }
        if (other.gameObject.CompareTag("Flame"))
        {
            isFlameCollided = true;
        }

    }

    void Update()
    {
        if (isBlockCollided && isFlameCollided)
        {

            DealDamage();
        }
    }

    void DealDamage()
    {
        currentHealth -= 10;
    }
}
