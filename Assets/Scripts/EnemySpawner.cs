using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public LayerMask obstacleLayer; // ��Q���Ƃ��ĔF������郌�C���[

    private int maxEnemyCount = 10; // �ŏ��̓G�̍ő吔
    private int currentEnemyCount = 0; // ���݂̓G�̐�

    public float firstSpawnDelay = 2f; // �ŏ��̓G�̐����܂ł̒x�����ԁi�b�j
    public float spawnIntervalEnemy1 = 1f; // �G1�̐����Ԋu�i�b�j

    private bool isSpawning = false; // �����𑱂��邩�ǂ����̃t���O
    private Coroutine spawnCoroutine; // �G�����R���[�`���̎Q�Ƃ�ێ�����

    private void Start()
    {
        // �G�̐������J�n
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
            // �G�̐����ʒu�������_���Ɍ���iY���͌Œ肵�Ȃ��j
            Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), 0f);

            // ��Q���Ƃ̏Փ˂�����Ȃ���G�𐶐�
            if (spawnPosition != Vector3.zero)
            {
                GameObject enemyInstance = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

                // ��̖ڂ̂݃X�P�[����ݒ�
                if (i == 0)
                {
                    enemyInstance.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                }

                currentEnemyCount++;
            }

            yield return new WaitForSeconds(spawnIntervalEnemy1);
        }

        // 10�̓G�𐶐�������A�������~
        StopSpawning();
    }

    // �������~���郁�\�b�h
    void StopSpawning()
    {
        isSpawning = false;
        if (spawnCoroutine != null)
            StopCoroutine(spawnCoroutine);
    }
}
