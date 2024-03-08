using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;  //�̗͂̍ő�l
    private int nowHealth;�@     //���݂̗̑�

    private bool isDamaged = false;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = nowHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (!isDamaged)
            {
                isDamaged = true;
                InvokeRepeating("TakeDamage", 0.5f, 0.5f); // 0.5�b���Ƃ�TakeDamage���\�b�h���Ăяo��
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            CancelInvoke("TakeDamage"); // �_���[�W���󂯂Ȃ��Ȃ�����Invoke���L�����Z������
            isDamaged = false;
        }
    }

    private void TakeDamage()
    {
        nowHealth -= 5; // �̗͂����炷

        if (nowHealth <= 0)
        {

        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
