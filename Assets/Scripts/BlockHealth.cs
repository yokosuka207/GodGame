using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockHealth : MonoBehaviour
{
    
    [SerializeField] private int health = 20;
    [SerializeField] private int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("UpFlame") ||
            collision.gameObject.CompareTag("UnderFlame") ||
            collision.gameObject.CompareTag("RightFlame") ||
            collision.gameObject.CompareTag("LeftFlame"))
        {
            health = health - damage;

            if (health <= 0)
            {

            Destroy(this.gameObject);

            }

        }
    }
}
