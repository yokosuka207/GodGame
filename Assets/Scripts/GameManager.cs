using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // シングルトンインスタンス
    public static int enemyKillCount = 0;
    public int clearKillCount = 2; //クリア条件として倒すべき敵の数
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        Debug.Log("Current Enemy Kill Count: " + enemyKillCount);
        if (enemyKillCount >= clearKillCount)
        {
            LoadClearScene();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver Scene"); //ゲームオーバーシーン
    }
    public void LoadClearScene()
    {
        Debug.Log("Loading Clear Scene...");
        SceneManager.LoadScene("Clear Scene"); // ゲームクリアシーン
    }
    public void EnemyKilled()
    {
        enemyKillCount++;
        Debug.Log("Enemy Killed. Total Kills: " + enemyKillCount);

        if (enemyKillCount == clearKillCount)
        {
            LoadClearScene();
        }
    }

    void ShowClearScreen()
    {
        Debug.Log("Game Cleared!");
    }
}
