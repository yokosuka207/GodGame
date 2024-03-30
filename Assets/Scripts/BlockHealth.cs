using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlockHealth : MonoBehaviour
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



   // private void OnTriggerEnter2D(Collider2D collision)
   //    {
   //       if (collision.gameObject.CompareTag("Flame"))
   //       {
   //           foreach (var pos in tilemap.cellBounds.allPositionsWithin)
   //           {
   //               // 取り出した位置情報からタイルマップ用の位置情報(セル座標)を取得
   //               Vector3Int cellPosition = new Vector3Int(pos.x, pos.y, pos.z);
   //
   //               if (tilemap.HasTile(cellPosition))
   //              {
   //
   // 特定のスプライトと一致している場合は別のタイルを設定する
   //    tilemap.SetTile(cellPosition, replaceTile);

    //                       health = health - damage;
    //
    //                       if (health <= 0)
    //                       {
    //                           tilemap.SetTile(cellPosition, null);

    //                       }



    //                }
    //
    //
    //
    //            }
    //       }
    //
    //        
    //    }


}
