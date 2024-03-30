using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Block : MonoBehaviour
{

    [SerializeField] private int health = 20;
    [SerializeField] private int damage = 10;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.gameObject.CompareTag("Flame"))
        {
            health = health - damage;

            if (health <= 0)
            {

                Destroy(this.gameObject);

            }

        }




    }
}