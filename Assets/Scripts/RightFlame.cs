using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightFlame : MonoBehaviour
{
    cameraManager cm;

    private void Start()
    {
        GameObject objParent = transform.parent.gameObject;
        cm = objParent.GetComponent<cameraManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            cm.SetFlameObj("RightFlame");
        }
    }
}
