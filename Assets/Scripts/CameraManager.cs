using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{

    [SerializeField] private GameObject target;         // 追従する対象を決める変数
    [SerializeField] private float stopTime = 0.2f;
    private bool isMovecam = true;
    private string flameObj;

    // Update is called once per frame
    void Update()
    {
        Camera.main.gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10); //　カメラの位置に変数cameraPosの位置を入れる
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

    public void SetFlameObj(string Obj)
    {
        flameObj = Obj;
    }

    public string GetFlameObj()
    {
        return flameObj;
    }

    public bool Returncam()
    {
        return isMovecam;
    }
}
