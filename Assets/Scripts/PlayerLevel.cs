using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLevel : MonoBehaviour
{
    public int experiencePoints = 0;    // プレイヤーの経験値
    public int level = 1;               // プレイヤーのレベル
    private int levelUpBorder = 10;     //レベルアップに必要な経験値

    // Start is called before the first frame update
    void Start()
    {
        // エネミーの死亡イベントを読み込む
        //FindObjectOfType<EnemyHealth>().death.AddListener(GainExperience);
    }

    //エネミーが死亡したら呼び出される
    public void GainExperience()
    {
        experiencePoints += 1;

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


    

    // Update is called once per frame
    void Update()
    {
        
    }
}