using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public float speed = 5.0f;
    private Transform target;
    public Transform startPoint; // �n�_
    public Transform endPoint; // �I�_

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
   
        
    }
    // Update is called once per frame
    void Update()
    {
        startPoint = transform;
        endPoint = target;
      
        if (target == null)
           return;
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // �v���C���[�Ɍ������Ĉړ�
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        //RaycastHit hitInfo;
        //if (Physics.Raycast(startPoint.position, endPoint.position - startPoint.position, out hitInfo, Vector3.Distance(startPoint.position, endPoint.position)))
        //{
        //    // �Փ˂����I�u�W�F�N�g������ꍇ�̏���
        //    Vector2 blockdodge = new Vector2(0, 1);
        //    transform.Translate(blockdodge * speed * Time.deltaTime);
        //    Debug.Log("�Փ˂����I�u�W�F�N�g�F" + hitInfo.collider.gameObject.name);
        //}

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("block"))
        {
            Vector2 blockdodge = new Vector2(0, 1);
            transform.Translate(blockdodge * speed * Time.deltaTime);
        }
    }
}
