using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;  //体力の最大値
    private int nowHealth;　     //現在の体力

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
                InvokeRepeating("TakeDamage", 0.5f, 0.5f); // 0.5秒ごとにTakeDamageメソッドを呼び出す
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            CancelInvoke("TakeDamage"); // ダメージを受けなくなったらInvokeをキャンセルする
            isDamaged = false;
        }
    }

    private void TakeDamage()
    {
        nowHealth -= 5; // 体力を減らす

        if (nowHealth <= 0)
        {

        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
