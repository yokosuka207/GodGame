using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10; // �G�l�~�[�̍ő�w���X
    public int currentHealth; // ���݂̃w���X

    bool isBlockCollided = false;
    bool isFlameCollided = false;

    private int experiencePointsE = 1; //�G�l�~�[�ɓ���Ă���o���l

    void Start()
    {
        currentHealth = maxHealth; // �ő�w���X�ŏ�����
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
        currentHealth -= 1;
        if (currentHealth <= 0)
        {
            Die(); // �w���X��0�ȉ��ɂȂ�����Die���\�b�h���Ăяo��
        }
    }

    public void OnDestroy()
    {
        // �G�l�~�[�����S�����Ƃ��Ɍo���l���v���C���[�ɓn��
        PlayerLevel playerExperience = FindObjectOfType<PlayerLevel>();
        if (playerExperience != null)
        {
            playerExperience.GainExperience(experiencePointsE);
        }
        else
        {
           
        }
        //FindObjectOfType<PlayerLevel>().GainExperience(experiencePointsE);
    }

    void Die()
    {
        // �G�l�~�[������
        Destroy(gameObject);

        //�v���C���[�Ɍo���l�������n��
        OnDestroy();

        // �v���C���[�ɃG�l�~�[�����S�������Ƃ�ʒm����
        PlayerHealth player = FindObjectOfType<PlayerHealth>();
        if (player != null)
        {
            player.EnemyDied();
        }
    }

}
