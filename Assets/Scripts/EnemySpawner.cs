using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public LayerMask obstacleLayer; // 障害物として認識されるレイヤー

    private int maxEnemyCount = 10; // 最初の敵の最大数
    private int currentEnemyCount = 0; // 現在の敵の数

    public float firstSpawnDelay = 2f; // 最初の敵の生成までの遅延時間（秒）
    public float spawnIntervalEnemy1 = 1f; // 敵1の生成間隔（秒）

    private bool isSpawning = false; // 生成を続けるかどうかのフラグ
    private Coroutine spawnCoroutine; // 敵生成コルーチンの参照を保持する

    private void Start()
    {
        // 敵の生成を開始
        StartSpawning();
    }

    public void StartSpawning()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            spawnCoroutine = StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(firstSpawnDelay);

        for (int i = 0; i < maxEnemyCount; i++)
        {
            // 敵の生成位置をランダムに決定（Y軸は固定しない）
            Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 0f);

            // 障害物との衝突を避けながら敵を生成
            if (spawnPosition != Vector3.zero)
            {
                GameObject enemyInstance = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

                // 一体目のみスケールを設定
                if (i == 0)
                {
                    enemyInstance.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }

                currentEnemyCount++;
            }

            yield return new WaitForSeconds(spawnIntervalEnemy1);
        }

        // 10個の敵を生成したら、生成を停止
        StopSpawning();
    }

    // 生成を停止するメソッド
    void StopSpawning()
    {
        isSpawning = false;
        if (spawnCoroutine != null)
            StopCoroutine(spawnCoroutine);
    }
}
