using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLevel : MonoBehaviour
{
    public static PlayerLevel instance;

    public float experiencePoints = 0;        // プレイヤーの経験値
    public int level = 1; // プレイヤーのレベル
    public float levelUpBorder = 10;         // レベルアップに必要な経験値

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    //エネミーが死亡したら呼び出される
    public void GainExperience(int experienceAmount)
    {
        experiencePoints += experienceAmount;

        if (experiencePoints >= levelUpBorder)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;

        levelUpBorder += 5;
        experiencePoints -= (levelUpBorder - 5);
    }

    public int GetLevel()
    {
        return level;
    }
    

    // Update is called once per frame
    void Update()
    {

    }
}