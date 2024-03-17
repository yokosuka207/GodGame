using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10; //エネミーの最大ヘルス
    public int currentHealth; //現在のヘルス

    void Start()
    {
        currentHealth = maxHealth; //最大ヘルスで初期化
    }

    void Update()
    {

    }
}
