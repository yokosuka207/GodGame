using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerLevel : MonoBehaviour
{
    public int experiencePoints = 0;    // �v���C���[�̌o���l
    public int level = 1;               // �v���C���[�̃��x��
    private int levelUpBorder = 10;     //���x���A�b�v�ɕK�v�Ȍo���l

    // Start is called before the first frame update
    void Start()
    {
        // �G�l�~�[�̎��S�C�x���g��ǂݍ���
        //FindObjectOfType<EnemyHealth>().death.AddListener(GainExperience);
    }

    //�G�l�~�[�����S������Ăяo�����
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