using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10; // エネミーの最大ヘルス
    public int currentHealth; // 現在のヘルス

    bool isBlockCollided = false;
    bool isFlameCollided = false;

    private int experiencePointsE = 1; //エネミーに内包している経験値

    void Start()
    {
        currentHealth = maxHealth; // 最大ヘルスで初期化
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // 衝突したオブジェクトがオブジェクト2(Block)である場合
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
            Die(); // ヘルスが0以下になったらDieメソッドを呼び出す
        }
    }

    public void OnDestroy()
    {
        // エネミーが死亡したときに経験値をプレイヤーに渡す
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
        // エネミーを消す
        Destroy(gameObject);

        //プレイヤーに経験値を引き渡す
        OnDestroy();

        // プレイヤーにエネミーが死亡したことを通知する
        PlayerHealth player = FindObjectOfType<PlayerHealth>();
        if (player != null)
        {
            player.EnemyDied();
        }
    }

}
