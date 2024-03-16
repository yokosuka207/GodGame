using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{

    public GameObject target; // �Ǐ]����Ώۂ����߂�ϐ�
    Vector3 pos;              // �J�����̏����ʒu���L�����邽�߂̕ϐ�

    //��~�@�\�H��

    //public float stop;               // ��~�p�ϐ�
    //public bool isHit;
    //public bool StopPlayer()
    //{
    //    return isHit;
    //}



    // Start is called before the first frame update
    void Start()
    {
        pos = Camera.main.gameObject.transform.position; //�J�����̏����ʒu��ϐ�pos�ɓ����
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = target.transform.position; // cameraPos�Ƃ����ϐ������A�Ǐ]����Ώۂ̈ʒu������

        // �����Ώۂ̉��ʒu��0��菬�����ꍇ
        if (target.transform.position.x < 0)
        {
            cameraPos.x = 0; // �J�����̉��ʒu��0������
        }

        // �����Ώۂ̏c�ʒu��0��菬�����ꍇ
        if (target.transform.position.y < 0)
        {
            cameraPos.y = 0;  // �J�����̏c�ʒu��0������
        }

        // �����Ώۂ̏c�ʒu��0���傫���ꍇ
        if (target.transform.position.y > 0)
        {
            cameraPos.y = target.transform.position.y;   // �J�����̏c�ʒu�ɑΏۂ̈ʒu������
        }

        cameraPos.z = -10; // �J�����̉��s���̈ʒu��-10������
        Camera.main.gameObject.transform.position = cameraPos; //�@�J�����̈ʒu�ɕϐ�cameraPos�̈ʒu������

    }
}
