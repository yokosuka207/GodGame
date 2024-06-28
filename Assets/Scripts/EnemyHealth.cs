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

    public GameObject DeathEffectPrefab; // エフェクトのプレハブを指定
    public float deathEffectDuration = 0.2f; // エフェクトの持続時間を指定

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
        if (other.gameObject.CompareTag("UpFlame") ||
            other.gameObject.CompareTag("UnderFlame") ||
            other.gameObject.CompareTag("RightFlame") ||
            other.gameObject.CompareTag("LeftFlame"))
        {
            isFlameCollided = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 衝突したオブジェクトがオブジェクト2(Block)である場合
        if (collision.gameObject.CompareTag("Block"))
        {
            isBlockCollided = false;
        }
        if (collision.gameObject.CompareTag("UpFlame") ||
            collision.gameObject.CompareTag("UnderFlame") ||
            collision.gameObject.CompareTag("RightFlame") ||
            collision.gameObject.CompareTag("LeftFlame"))
        {
            isFlameCollided = false;
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

    void OnDestroy()
    {
        // エネミーが死亡したときに経験値をプレイヤーに渡す
        PlayerLevel playerExperience = FindObjectOfType<PlayerLevel>();
        if (playerExperience != null)
        {
            playerExperience.GainExperience(experiencePointsE);
        }

        // プレイヤーにエネミーが死亡したことを通知する
        PlayerHealth player = FindObjectOfType<PlayerHealth>();
        if (player != null)
        {
            player.EnemyDied();
        }
    }

    void Die()
    {
        // 死亡エフェクトを発生させる
        SpawnDeathEffect();

        // エネミーを消す
        Destroy(gameObject);

        //プレイヤーに経験値を引き渡す
        OnDestroy();
    }

    void SpawnDeathEffect()
    {
        if (DeathEffectPrefab != null)
        {
            // エフェクトを敵キャラクターの位置に生成
            GameObject effect = Instantiate(DeathEffectPrefab, transform.position, transform.rotation);

            // 一定時間後にエフェクトを破壊
            Destroy(effect, deathEffectDuration);
        }
        else
        {
            Debug.LogWarning("Death effect prefab is not assigned.");
        }
    }

    public void SetDeathEffect(GameObject newEffectPrefab)
    {
        DeathEffectPrefab = newEffectPrefab;
    }
}
