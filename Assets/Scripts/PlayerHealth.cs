using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;  //体力の最大値
    public int nowHealth;　     //現在の体力

    private bool isDamaged = false;

    // Start is called before the first frame update
    void Start()
    {
        nowHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (!isDamaged)
            {
                isDamaged = true;
                InvokeRepeating("TakeDamage", 0.5f, 0.5f); // 0.5秒ごとにTakeDamageを呼び出す
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
        Debug.Log("5ダメージ");
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
