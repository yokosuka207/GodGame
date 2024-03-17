using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{

    [SerializeField] private float stopTime = 0.2f;
    [SerializeField] private GameObject target;         // �Ǐ]����Ώۂ����߂�ϐ�
    private bool isMovecam = true;

    // Update is called once per frame
    void Update()
    {
        Camera.main.gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10); //�@�J�����̈ʒu�ɕϐ�cameraPos�̈ʒu������
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Block"))
        {
            isMovecam = false;
            Invoke("IsCameraFree", stopTime);
        }
    }

    private void IsCameraFree()
    {
        isMovecam = true;
    }

    public bool Returncam()
    {
        return isMovecam;
    }


}
