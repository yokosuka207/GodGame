using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10; //�G�l�~�[�̍ő�w���X
    public int currentHealth; //���݂̃w���X

    void Start()
    {
        currentHealth = maxHealth; //�ő�w���X�ŏ�����
    }

    void Update()
    {

    }
}
